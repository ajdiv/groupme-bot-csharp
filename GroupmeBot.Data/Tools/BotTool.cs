using GroupmeBot.Data.Commands;
using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.WebHelpers.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class BotTool : IBotTool
    {
        private readonly GroupmeBotAccountDetails _botDetails;
        private readonly ICommandFactory _cmdFactory;
        private readonly IHttpClientWrapper _client;

        private readonly string _gmePostAddress = "https://api.groupme.com/v3/bots/post";

        public BotTool(IOptions<GroupmeBotAccountDetails> botDetails, ICommandFactory commandFactory, IHttpClientWrapper client)
        {
            _botDetails = botDetails.Value ?? throw new ArgumentException(nameof(botDetails));
            _cmdFactory = commandFactory;
            _client = client;
        }

        public async Task ProcessMessage(GroupmeBotRequestModel message)
        {
            if (message.SenderType == GroupmeSenderType.User && !string.IsNullOrWhiteSpace(message.Text))
            {
                var command = _cmdFactory.GetCommand(message.Text.Trim().ToLower());
                if (command == null) return;

                var results = await command.Execute();

                await SendMessage(results);
            }
        }

        public async Task ProcessExternalPostRequest(BotPostRequestModel reqModel)
        {
            var result = new GroupmeBotResponseModel();
            if (reqModel.EventType == ExternalEventTypes.TwitchStreamStart)
            {
                result.Text = $"We are LIVE at https://www.twitch.tv/{reqModel.Text}";
            }
            else
            {
                result.Text = reqModel.Text;
            }
            await SendMessage(result);
        }

        private async Task SendMessage(GroupmeBotResponseModel model)
        {
            model.BotId = _botDetails.BotApiKey;
            await _client.Post(_gmePostAddress, model);
        }
    }
}
