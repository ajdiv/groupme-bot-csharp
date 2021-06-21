﻿using GroupmeBot.Data.Commands;
using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class BotTool : IBotTool
    {
        private readonly GroupmeBotAccountDetails _botDetails;
        private readonly ICommandFactory _cmdFactory;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string gmePostAddress = "https://api.groupme.com/v3/bots/post";

        public BotTool(IOptions<GroupmeBotAccountDetails> botDetails, ICommandFactory commandFactory, IHttpClientFactory clientFactory)
        {
            _botDetails = botDetails.Value ?? throw new ArgumentException(nameof(botDetails));
            _cmdFactory = commandFactory;
            _httpClientFactory = clientFactory;
        }

        public async Task ProcessMessage(GroupmeRequestModel message)
        {
            if (message.SenderType == GroupmeSenderType.User)
            {
                var hi = _cmdFactory.GetCommand(message.Text);
                var returnMsg = new StringContent(@$"{{""bot_id"":""{_botDetails.BotApiKey}"",""text"":""YOU SAID {message.Text}""}}", System.Text.Encoding.UTF8, "application/json");

                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.PostAsync(gmePostAddress, returnMsg);
            }
        }
    }
}
