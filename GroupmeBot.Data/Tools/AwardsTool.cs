using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class AwardsTool : IAwardsTool
    {
        private readonly IGroupmeTool _gmeTool;
        private readonly int startOfDayHour = 4;


        public AwardsTool(IGroupmeTool gmeTool)
        {
            _gmeTool = gmeTool;
        }

        public async Task<string> GetAwards()
        {
            var todayTomorrow = GetTodayAndTomorrow();
            var begin = todayTomorrow.Item1;
            var end = todayTomorrow.Item2;

            var keepLooping = true;
            string beforeId = null;

            var userStats = new List<UserStatsModel>();

            while (keepLooping)
            {
                var messages = await _gmeTool.GetMessages(100, beforeId, null);
                messages = messages.Where(x => x.SenderType != GroupmeSenderType.Bot && !x.System).ToList();
                foreach (var message in messages)
                {
                    if (message.CreatedAt <= begin)
                    {
                        keepLooping = false;
                        break;
                    }

                    var user = userStats.SingleOrDefault(x => x.UserId == message.UserId);
                    if (user == null)
                    {
                        user = new UserStatsModel()
                        {
                            UserId = message.UserId,
                            Nickname = message.Name
                        };
                        userStats.Add(user);
                    }

                    user.MessageCount++;

                    var likedBy = message.FavoritedBy.Where(x => x.ToString() != user.UserId);
                    user.LikeCount += likedBy.Count();

                    beforeId = message.Id;
                }
            }

            var result = "";
            result += GetTopMessages(userStats);
            result += '\n';
            result += '\n';
            result += GetMostLikeable(userStats);
            return result;
        }

        private string GetMostLikeable(IList<UserStatsModel> userStats)
        {
            var likeableString = "Most Likeable:\n    ";
            var likeableResults = new List<string>();

            var likeableUsers = userStats.OrderByDescending(x => x.LikeCount / x.MessageCount);

            foreach (var stats in likeableUsers)
            {
                var likeSuffix = stats.LikeCount == 1 ? "" : "s";
                var messageSuffix = stats.MessageCount == 1 ? "" : "s";

                likeableResults.Add($"{stats.Nickname} ({stats.LikeCount} like{likeSuffix} in {stats.MessageCount} message{messageSuffix})");
            }

            for (int i = 0; i < likeableResults.Count; i++)
            {
                likeableString += likeableResults[i];
                if (i != likeableResults.Count - 1)
                {
                    likeableString += "\n    ";
                }
            }

            return likeableString;
        }

        private Tuple<DateTime, DateTime> GetTodayAndTomorrow()
        {
            var begin = DateTime.Now.Hour < startOfDayHour ? DateTime.Now.AddDays(-1).Date.AddHours(startOfDayHour) : DateTime.Now.Date.AddHours(startOfDayHour);
            var end = begin.AddDays(1).AddMilliseconds(-1);
            return Tuple.Create(begin, end);
        }

        private string GetTopMessages(IList<UserStatsModel> userStats)
        {
            var topMessageString = "Most Messages Sent:\n    ";
            var topMessageResults = new List<string>();

            var topMessages = userStats.OrderByDescending(x => x.MessageCount);

            foreach (var stats in topMessages)
            {
                topMessageResults.Add(stats.Nickname + " (" + stats.MessageCount + ")");
            }

            for (var i = 0; i < topMessageResults.Count; i++)
            {
                topMessageString += topMessageResults[i];
                // If we are at the end of the array, don't add dots
                if (i != topMessageResults.Count - 1)
                {
                    topMessageString += "\n    ";
                }
            }
            return topMessageString;
        }
    }
}
