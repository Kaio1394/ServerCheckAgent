using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Models;
using ServerCheckAgent.Models.Response;
using ServerCheckAgent.Services.Interfaces;
using ServerCheckAgent.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class ScriptsController : ControllerBase
    {
        private readonly ILogger<ScriptsController> _logger;
        private readonly IScriptsService _scriptsService;
        private readonly IWebHostEnvironment _env;

        public ScriptsController(IWebHostEnvironment env, ILogger<ScriptsController> logger, IScriptsService scriptsService)
        {
            _scriptsService = scriptsService;
            _logger = logger;
            _env = env;
        }

        [HttpPost("cmd/run")]
        public async Task<IActionResult> ExecuteScriptCmd([FromBody] Script script)
        {
            string pythonExePath = Path.Combine(_env.ContentRootPath, Variables.PathExecutablePython);
            string output = "";
            try
            {
                output = await _scriptsService.ExecuteScriptByCmd(script, pythonExePath);
                return Ok(new ResponseScript
                {
                    Output = output,
                    PathExecutable = pythonExePath
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseScript
                {
                    Output = $"{ex.Message}",
                    PathExecutable = pythonExePath
                });
            }
        }
    }
}
