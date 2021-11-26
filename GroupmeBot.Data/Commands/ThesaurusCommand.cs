using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class ThesaurusCommand : Command
    {
        private readonly IThesaurusTool _thesaurusTool;

        public override string[] CommandTextTriggers { get => new string[] { "/thesaurize" }; }

        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Start; }

        public override string HelpText { get => "get synonyms of the previous message"; }

        public ThesaurusCommand(IThesaurusTool thesaurusTool)
        {
            _thesaurusTool = thesaurusTool;
        }

        public override async Task<GroupmeBotResponseModel> Execute()
        {
            var text = await _thesaurusTool.ThesaurizeLastMessage();

            var results = new GroupmeBotResponseModel() { Text = text };

            return results;
        }
    }
}
