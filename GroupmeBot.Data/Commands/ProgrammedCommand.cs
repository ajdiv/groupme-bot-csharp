using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public abstract class ProgrammedCommand : Command
    {
        public abstract string[] CommandTextTriggers { get; }
        public abstract CommandMessageLocations CommandMessageLocation { get; }
        public abstract string HelpText { get; }
    }
}
