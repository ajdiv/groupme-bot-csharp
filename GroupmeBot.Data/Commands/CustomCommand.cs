using GroupmeBot.Data.Models.GroupMe;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class CustomCommand : Command
    {
        private readonly string _response;

        public CustomCommand(string response)
        {
            _response = response;
        }

        public override Task<GroupmeBotResponseModel> Execute()
        {
            var results = new GroupmeBotResponseModel() { Text = _response };
            return Task.FromResult(results);
        }
    }
}
