using GroupmeBot.Data.Commands;
using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Models.Wordle;
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
        private readonly IWordleTool _wordleTool;

        private readonly string _gmePostAddress = "https://api.groupme.com/v3/bots/post";

        public BotTool(IOptions<GroupmeBotAccountDetails> botDetails, ICommandFactory commandFactory, IHttpClientWrapper client, IWordleTool wordleTool)
        {
            _botDetails = botDetails.Value ?? throw new ArgumentException(nameof(botDetails));
            _cmdFactory = commandFactory;
            _client = client;
            _wordleTool = wordleTool;
        }

        public async Task ProcessMessage(GroupmeBotRequestModel message)
        {
            if (message.SenderType == GroupmeSenderType.User && !string.IsNullOrWhiteSpace(message.Text))
            {
                Console.WriteLine($"Received message: {message.Text} from {message.Nickname} at {message.CreatedAt}");
                var command = await _cmdFactory.GetCommand(message.Text.Trim().ToLower());

                if (command != null)
                {
                    var results = await command.Execute(message.Text);
                    await SendMessage(results);
                }
                else if (WordleSubmissionModel.TryParse(message.Text, out WordleSubmissionModel validSubmission))
                {
                    var results = await _wordleTool.ProcessSubmission(validSubmission, message.UserId, message.Nickname);
                    await SendTextMessage(results);
                }
                else
                {
                    return;
                }
            }
        }

        public async Task SendTextMessage(string text)
        {
            var result = new GroupmeBotResponseModel
            {
                Text = text
            };
            await SendMessage(result);
        }

        private async Task SendMessage(GroupmeBotResponseModel model)
        {
            if (model == null) return;

            model.BotId = _botDetails.BotApiKey;
            await _client.Post(_gmePostAddress, model);
        }
    }
}
