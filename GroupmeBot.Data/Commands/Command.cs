using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public abstract class Command
    {
        public abstract Task<GroupmeBotResponseModel> Execute();
    }
}
