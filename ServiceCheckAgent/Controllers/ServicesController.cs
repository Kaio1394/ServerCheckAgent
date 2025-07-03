using Microsoft.AspNetCore.Mvc;

namespace ServiceCheckAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(ILogger<ServicesController> logger)
        {
            _logger = logger;
        }
    }
}
