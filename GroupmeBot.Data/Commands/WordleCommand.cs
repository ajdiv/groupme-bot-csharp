using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class WordleCommand : ProgrammedCommand
    {
        private readonly GroupmeTool _gmeTool;
        private readonly IWordleTool _wordleTool;

        public override string[] CommandTextTriggers { get => new string[] { "/wordle" }; }

        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Start; }

        public override string HelpText { get => "Returns wordle stats"; }

        public WordleCommand(GroupmeTool gmeTool, IWordleTool wordleTool)
        {
            _gmeTool = gmeTool;
            _wordleTool = wordleTool;
        }

        public override async Task<GroupmeBotResponseModel> Execute()
        {
            var todaysSubmissions = await _wordleTool.GetSubmissionsForToday();
            var allUsersInGroup = await _gmeTool.GetGroupMembers();
            var resultString = _wordleTool.GenerateWordleResultText(todaysSubmissions, allUsersInGroup);

            var results = new GroupmeBotResponseModel() { Text = resultString };
            return results;
        }
    }
}
