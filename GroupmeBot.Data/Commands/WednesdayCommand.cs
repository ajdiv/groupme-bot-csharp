using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class WednesdayCommand : ProgrammedCommand
    {

        public override string[] CommandTextTriggers { get => new string[] { "/wed", "/wednesday" }; }
        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Start; }
        public override string HelpText { get => "check what day it is"; }

        private readonly DayOfWeek dayINeed = DayOfWeek.Wednesday;

        public WednesdayCommand() { }

        public override Task<GroupmeBotResponseModel> Execute()
        {
            DateTime now = GetNowInEasternTime();
            
            string strResult;

            if (now.DayOfWeek == dayINeed)
            {
                strResult = "https://media.giphy.com/media/dvDCHPFnxnYubsrNvl/giphy.gif";
            }
            else
            {
                var daysToAdd = ((int)dayINeed - (int)now.DayOfWeek + 7) % 7;
                var targetDate = now.AddDays(daysToAdd).Date;

                var diffMinutes = Math.Ceiling((targetDate - now).TotalMinutes);
                var days = Math.Floor(diffMinutes / 60 / 24); // 60 mins in an hour, 24 hours in a day
                var daysTense = days == 1 ? "day" : "days";
                // Get total diff in hours, subtract what we have in days already
                var hours = Math.Floor(diffMinutes / 60) - (days * 24);
                var hoursTense = hours == 1 ? "hour" : "hours";
                // Get total diff in minutes, subtract what we have in days and hours already
                var mins = diffMinutes - hours * 60 - days * 24 * 60;
                var minsTense = mins == 1 ? "minute" : "minutes";

                strResult = $"It's {days} {daysTense}, {hours} {hoursTense}, and {mins} {minsTense} until Wednesday my dudes.";
            }

            var result = new GroupmeBotResponseModel() { Text = strResult };
            return Task.FromResult(result);
        }

        /// <summary>
        /// Running this in Docker (on Linux) provides DateTime.Now in UTC. Make sure we're returning in EST
        /// </summary>
        private DateTime GetNowInEasternTime()
        {
            var timeUtc = DateTime.UtcNow;
            var timezoneString = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "Eastern Standard Time" : "America/New_York";
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(timezoneString);
            DateTime now = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

            return now;
        }
    }
}
