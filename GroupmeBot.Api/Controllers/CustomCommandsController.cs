using GroupmeBot.Data.Models.CustomCommands;
using GroupmeBot.Data.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Api.Controllers
{
    [ApiController]
    [Route("customcommands")]
    public class CustomCommandsController : ControllerBase
    {
        private readonly ILogger<CustomCommandsController> _logger;
        private readonly ICustomCommandsTool _customCommandsTool;

        public CustomCommandsController(ILogger<CustomCommandsController> logger, ICustomCommandsTool customCommandsTool)
        {
            _logger = logger;
            _customCommandsTool = customCommandsTool;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomCommandModel>>> Get()
        {
            try
            {
                var results = await _customCommandsTool.GetAllCustomCommands();
                return StatusCode(200, results);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error retieving Custom Commands");
                return StatusCode(500, e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomCommandModel requestObj)
        {
            try
            {
                await _customCommandsTool.EditCommand(requestObj);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating Custom Command");
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomCommandModel requestObj)
        {
            try
            {
                await _customCommandsTool.CreateCommand(requestObj);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error creating Custom Command");
                return StatusCode(500, e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _customCommandsTool.DeleteCommand(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deleting Custom Command");
                return StatusCode(500, e);
            }
        }
    }
}
