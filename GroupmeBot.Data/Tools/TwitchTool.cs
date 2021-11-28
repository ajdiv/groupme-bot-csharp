﻿using GroupmeBot.Data.Models.Twitch;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class TwitchTool : ITwitchTool
    {
        private readonly IBotTool _botTool;

        public TwitchTool(IBotTool botTool)
        {
            _botTool = botTool;
        }

        public async Task GenerateStreamStartText(TwitchReqModel model)
        {
            var text = $"One of the Boyz is live on Twitch! {model.ChannelName} is playing {model.Game} " +
                $"for {model.CurrentViewers} people. Support your friend @ {model.ChannelUrl}";

            await _botTool.SendTextMessage(text);
        }
    }
}
