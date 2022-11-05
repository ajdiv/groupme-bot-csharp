using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class EventGroupFinderTool
    {
        private readonly GroupmeTool _groupmeTool;

        public EventGroupFinderTool(GroupmeTool gmeTool)
        {
            _groupmeTool = gmeTool;
        }

        public async Task<IList<string>> TryGetMembersOfEvent(string potentialGroupName)
        {
            // Get a list of all groups coming up
            var allEvents = await _groupmeTool.GetAllEvents();

            var matchingEvents = allEvents.Where(x => x.Name.ToLower() == potentialGroupName.ToLower()).FirstOrDefault();

            return matchingEvents?.Going;
        }
    }
}
