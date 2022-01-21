using GroupmeBot.Data.Models.Wordle;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface IWordleTool
    {
        Task<string> ProcessSubmission(WordleSubmissionModel submission, string userId, string userName);
    }
}
