using Microsoft.AspNetCore.Mvc;

namespace ServiceCheckAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScriptsController : ControllerBase
    {
        private readonly ILogger<ScriptsController> _logger;

        public ScriptsController(ILogger<ScriptsController> logger)
        {
            _logger = logger;
        }
    }
}
