using GroupmeBot.Data.Models.Twitch;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface ITwitchTool
    {
        public Task GenerateStreamStartText(TwitchReqModel model);
    }
}
