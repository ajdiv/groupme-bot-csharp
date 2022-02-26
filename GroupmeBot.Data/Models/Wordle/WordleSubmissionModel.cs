namespace GroupmeBot.Data.Models.Wordle
{
    public class WordleSubmissionModel
    {
        public int SolvedInAttempts { get; set; }
        public int SubmissionDayNum { get; set; }
        public bool IsHardMode { get; set; }

        public static bool TryParse(string input, out WordleSubmissionModel result)
        {
            result = null;

            var textArr = input.Trim().ToLower().Split(' ');

            if (textArr.Length < 3) return false;

            var validSubmissionDay = int.TryParse(textArr[1], out int submissionDay);
            var possibleFraction = ExtractFractionFromFinalSegment(textArr[2]);
            var isFraction = StringIsFraction(possibleFraction);

            if (textArr[0] != "wordle" || !validSubmissionDay || !isFraction) return false;

            var isSolved = int.TryParse(possibleFraction.Substring(0, possibleFraction.IndexOf('/')), out int numAttempts);
            var isHardMode = possibleFraction.Length > 3 && possibleFraction[3] == '*';

            result = new WordleSubmissionModel()
            {
                SolvedInAttempts = isSolved ? numAttempts : 0,
                SubmissionDayNum = submissionDay,
                IsHardMode = isHardMode
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
            var validFirstChar = (char.GetNumericValue(input, 0) >= 1 && char.GetNumericValue(input, 0) <= 6) || input[0] == 'x';
            var validSecondChar = input[1] == '/';
            var validThirdChar = char.GetNumericValue(input, 2) == 6;

            return validFirstChar && validSecondChar && validThirdChar;
        }

    }
}
