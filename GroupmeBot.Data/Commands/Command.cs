using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public abstract class Command
    {
        public abstract string[] CommandTextTriggers { get; }
        public abstract CommandMessageLocations CommandMessageLocation { get; }
        public abstract string HelpText { get; }

        public abstract Task<GroupmeBotResponseModel> Execute();
    }
}
