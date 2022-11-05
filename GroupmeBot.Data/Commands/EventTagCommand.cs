using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class EventTagCommand : Command
    {
        public IList<string> MembersToTag { get; set; }

        private readonly EventGroupFinderTool _eventGroupFinderTool;
        private readonly GroupmeTool _gmeTool;

        public EventTagCommand(GroupmeTool gmeTool, EventGroupFinderTool eventGroupFinderTool)
        {
            _eventGroupFinderTool = eventGroupFinderTool;
            _gmeTool = gmeTool;
        }

        public override async Task<GroupmeBotResponseModel> Execute()
        {
            var membersToTag = await _eventGroupFinderTool.TryGetMembersOfEvent(text);

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
