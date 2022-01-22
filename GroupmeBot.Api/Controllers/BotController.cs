using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
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
        [Route("testinput")]
        public IActionResult GetSampleGroupmeInput([FromBody] JsonElement rawData)
        {
            try
            {
                var message = $"Received {JsonSerializer.Serialize(rawData)}";
                _logger.LogInformation(message);
                return StatusCode(200, message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error processing message", rawData);
                return StatusCode(500, e);
            }
        }
    }
}
