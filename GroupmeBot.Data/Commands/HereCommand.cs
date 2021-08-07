using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class HereCommand : Command
    {
        private readonly IGroupmeTool _gmeTool;

        public override string[] CommandTextTriggers { get => new string[] { "@here", "@all" }; }

        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Contains; }

        public override string HelpText { get => "notifies everyone in the group, regardless of their mute settings"; }

        public HereCommand(IGroupmeTool gmeTool)
        {
            _gmeTool = gmeTool;
        }

        public override async Task<GroupmeBotResponseModel> Execute()
        {
            var tagProperties = await _gmeTool.TagAllMembersInGroup();
            var mentionsModel = new GroupmeMentionsModel()
            {
                Loci = tagProperties.Item2,
                UserIds = tagProperties.Item3
            };

            var results = new GroupmeBotResponseModel() { Text = tagProperties.Item1 };

            results.Attachments.Add(mentionsModel);

            return results;
        }
    }
}
