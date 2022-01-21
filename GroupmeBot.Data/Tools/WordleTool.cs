using GroupmeBot.Data.Models.Wordle;
using GroupmeBot.Data.Mongo.Models;
using GroupmeBot.Data.Mongo.Repositories;
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

        public async Task<string> ProcessSubmission(WordleSubmissionModel submission, string userId, string userName)
        {
            var existingEntry = await _wordleRecordRepo.GetExistingWordleRecord(submission.SubmissionDayNum, userId);
            if (existingEntry != null) return "Your Wordle submission is already submitted for today";

            var wordleRecord = new WordleRecord()
            {
                DailySubmissionIdentifier = submission.SubmissionDayNum,
                SolvedInAttempts = submission.SolvedInAttempts,
                UserId = userId
            };

            await _wordleRecordRepo.Create(wordleRecord);
            return $"{userName}'s Wordle submission is logged!";
        }
    }
}
