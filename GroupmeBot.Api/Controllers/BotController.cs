using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GroupmeBot.Api.Controllers
{
    [ApiController]
    [Route("bot")]
    public class BotController : ControllerBase
    {
        private readonly ILogger<BotController> _logger;
        private readonly IBotTool _botTool;

        public BotController(ILogger<BotController> logger, IBotTool botTool)
        {
            _logger = logger;
            _botTool = botTool;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupmeBotRequestModel message)
        {
            try
            {
                await _botTool.ProcessMessage(message);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error processing message", message);
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("sendmessage")]
        public async Task<IActionResult> SendMessage([FromBody] BotPostRequestModel reqModel)
        {
            try
            {
                await _botTool.ProcessExternalPostRequest(reqModel);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error sending message", reqModel.Text);
                return StatusCode(500, e);
            }
        }
    }
}
