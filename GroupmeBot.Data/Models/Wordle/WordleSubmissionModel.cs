using System.Text.RegularExpressions;

namespace GroupmeBot.Data.Models.Wordle
{
    public class WordleSubmissionModel
    {
        public int SolvedInAttempts { get; set; }
        public int SubmissionDayNum { get; set; }

        public static bool TryParse(string input, out WordleSubmissionModel result)
        {
            result = null;

            var textArr = input.Trim().ToLower().Split(' ');

            if (textArr.Length != 3) return false;

            var validSubmissionDay = int.TryParse(textArr[1], out int submissionDay);
            var possibleFraction = ExtractFractionFromFinalSegment(textArr[2]);
            var isFraction = StringIsFraction(possibleFraction);

            if (textArr[0] != "wordle" || !validSubmissionDay || !isFraction) return false;

            var isSolved = int.TryParse(possibleFraction.Substring(0, possibleFraction.IndexOf('/')), out int numAttempts);

            result = new WordleSubmissionModel()
            {
                SolvedInAttempts = isSolved ? numAttempts : 0,
                SubmissionDayNum = submissionDay
            };

            return true;
        }

        private static string ExtractFractionFromFinalSegment(string input)
        {
            var index = input.IndexOf('\n');
            var result = index > 0 ? input.Substring(0, index) : string.Empty;

            return result;
        }

        private static bool StringIsFraction(string input)
        {
            var pattern = @"^\d+(\/\d+)$";
            var isValidFraction = Regex.IsMatch(input, pattern);
            var isFailedAttempt = input.StartsWith("x/");
            return isValidFraction || isFailedAttempt;
        }

    }
}
