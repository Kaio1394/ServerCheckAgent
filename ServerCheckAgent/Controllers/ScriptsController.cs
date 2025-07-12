using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class ScriptsController : ControllerBase
    {
        private readonly ILogger<ScriptsController> _logger;

        public ScriptsController(ILogger<ScriptsController> logger)
        {
            _logger = logger;
        }
    }
}
