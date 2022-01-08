using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class SiteCommand : ProgrammedCommand
    {
        private readonly ITextTool _textTool;

        public override string[] CommandTextTriggers { get => new string[] { "/site", "/website", "/url" }; }

        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Start; }

        public override string HelpText { get => "boyz homepage"; }

        public SiteCommand(ITextTool textTool)
        {
            _textTool = textTool;
        }

        public override Task<GroupmeBotResponseModel> Execute()
        {
            var url = _textTool.GetSiteUrl();
            var result = new GroupmeBotResponseModel() { Text = url };
            return Task.FromResult(result);
        }
    }
}
