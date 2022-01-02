using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class CoolGuyCommand : Command
    {
        private readonly ICoolGuyTool _coolGuyTool;

        public override string[] CommandTextTriggers { get => new string[] { "/coolguy", "/cool guy" }; }

        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Start; }

        public override string HelpText { get => "makes you a cool guy"; }

        public CoolGuyCommand(ICoolGuyTool tool)
        {
            _coolGuyTool = tool;
        }

        public override Task<GroupmeBotResponseModel> Execute()
        {
            var face = _coolGuyTool.GetRandomFace();
            var result = new GroupmeBotResponseModel() { Text = face };
            return Task.FromResult(result);
        }
    }
}
