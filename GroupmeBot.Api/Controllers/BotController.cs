using GroupmeBot.Data.Commands;
using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GroupmeBot.Api.Controllers
{
    [ApiController]
    [Route("bot")]
    public class BotController : ControllerBase
    {
        static HttpClient client = new HttpClient();

        private readonly ILogger<BotController> _logger;
        private readonly GroupmeBotAccountDetails _botDetails;
        private readonly ICommandFactory _cmdFactory;

        public BotController(ILogger<BotController> logger, IOptions<GroupmeBotAccountDetails> botDetails, ICommandFactory commandFactory)
        {
            _logger = logger;
            _cmdFactory = commandFactory;
            _botDetails = botDetails.Value ?? throw new ArgumentException(nameof(botDetails));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupmeRequestModel message)
        {
            if (message.SenderType == GroupmeSenderType.User)
            {
                var test = _botDetails.BotApiKey;
                var hi = _cmdFactory.GetCommand(message.Text);
                var returnMsg = new StringContent("{\"bot_id\":\"6cc97c95a3c1d4340ea13bbc00\",\"text\":\"YOU SAID " + test + "\"}", System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://api.groupme.com/v3/bots/post", returnMsg);
                return Ok(test);
            }

            return Ok();
        }
    }
}
