using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Models.Wordle;
using GroupmeBot.Data.Mongo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface IWordleTool
    {
        string GenerateWordleResultText(IList<WordleRecord> records, IList<GroupmeUserModel> allUsers);
        Task<IList<WordleRecord>> GetSubmissionsForToday();
        Task<string> ProcessSubmission(WordleSubmissionModel submission, string userId, string userName);
    }
}
