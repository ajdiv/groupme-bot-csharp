using GroupmeBot.Data.Constants;

namespace GroupmeBot.Data.Commands
{
    public abstract class Command
    {
        public abstract string[] CommandTextTriggers { get; }
        public abstract CommandMessageLocations CommandMessageLocation { get; }
        public abstract string HelpText { get; }

        public abstract void Execute();
    }
}
