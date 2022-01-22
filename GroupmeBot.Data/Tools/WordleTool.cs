using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Models.Wordle;
using GroupmeBot.Data.Mongo.Models;
using GroupmeBot.Data.Mongo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class WordleTool : IWordleTool
    {
        private readonly WordleRecordRepository _wordleRecordRepo;

        public WordleTool(WordleRecordRepository wordleRecordRepo)
        {
            _wordleRecordRepo = wordleRecordRepo;
        }

        public string GenerateWordleResultText(IList<WordleRecord> records, IList<GroupmeUserModel> allUsers)
        {
            if (!records.Any()) return "No one played yet today";

            var sortedPlays = records.OrderBy(x => x.SolvedInAttempts).ToList();
            var winningAttempt = sortedPlays.FirstOrDefault(x => x.SolvedInAttempts > 0)?.SolvedInAttempts ?? 0;

            var results = "Standings:\n";
            foreach (var play in sortedPlays)
            {
                var player = allUsers.Single(x => x.UserId == play.UserId).Nickname;
                var winnerEmoji = play.SolvedInAttempts == winningAttempt && winningAttempt > 0 ? "👑" : string.Empty;
                results += $"{player}{winnerEmoji}: {play.SolvedInAttempts}/6\n";
            }

            var unplayedList = new List<string>();
            var unplayedPlayerIds = allUsers.Select(x => x.UserId).Except(records.Select(x => x.UserId)).ToList();

            results += unplayedPlayerIds.Any() ? "\nNot Yet Played:" : string.Empty;
            foreach (var unplayerId in unplayedPlayerIds)
            {
                var unplayer = allUsers.Single(x => x.UserId == unplayerId).Nickname;
                results += $"\n{unplayer}";
            }

            return results;
        }

        public async Task<IList<WordleRecord>> GetSubmissionsForToday()
        {
            var records = await _wordleRecordRepo.GetSubmissionsForToday();
            return records;
        }

        public async Task<string> ProcessSubmission(WordleSubmissionModel submission, string userId, string userName)
        {
            var existingEntry = await _wordleRecordRepo.GetExistingWordleRecord(submission.SubmissionDayNum, userId);
            if (existingEntry != null) return $"{userName}'s Wordle submission was already submitted for today";

            var wordleRecord = new WordleRecord()
            {
                DailySubmissionIdentifier = submission.SubmissionDayNum,
                SolvedInAttempts = submission.SolvedInAttempts,
                UserId = userId,
                SubmissionDate = DateTime.Now.Date
            };

            await _wordleRecordRepo.Create(wordleRecord);
            return $"{userName}'s Wordle submission is logged!";
        }
    }
}
