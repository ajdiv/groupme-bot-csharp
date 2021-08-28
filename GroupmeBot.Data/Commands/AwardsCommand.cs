using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class AwardsCommand : Command
    {
        private readonly IAwardsTool _awardsTool;

        public override string[] CommandTextTriggers { get => new string[] { "/awards" }; }

        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Start; }

        public override string HelpText { get => "gets the most active and most liked messages from today"; }

        public AwardsCommand(IAwardsTool tool)
        {
            _awardsTool = tool;
        }

        public override async Task<GroupmeBotResponseModel> Execute()
        {
            var awards = await _awardsTool.GetAwards();
            var result = new GroupmeBotResponseModel() { Text = awards };
            return result;
        }
    }
}
