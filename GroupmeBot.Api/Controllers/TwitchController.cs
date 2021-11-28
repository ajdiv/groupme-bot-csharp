using GroupmeBot.Data.Models.Twitch;
using GroupmeBot.Data.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GroupmeBot.Api.Controllers
{
    [ApiController]
    [Route("twitch")]
    public class TwitchController : ControllerBase
    {
        private readonly ILogger<BotController> _logger;
        private readonly ITwitchTool _twitchTool;

        public TwitchController(ILogger<BotController> logger, ITwitchTool twitchTool)
        {
            _logger = logger;
            _twitchTool = twitchTool;
        }

        [HttpPost]
        [Route("islive")]
        public async Task<IActionResult> SendIsLiveMessage([FromBody] TwitchReqModel reqModel)
        {
            try
            {
                await _twitchTool.GenerateStreamStartText(reqModel);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error sending Twitch Live message", reqModel);
                return StatusCode(500, e);
            }
        }
    }
}
