using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesWindowsController : ControllerBase
    {
        private readonly ILogger<ServicesWindowsController> _logger;
        private readonly IServicesWindowsService _servicesWindowsService;

        public ServicesWindowsController(ILogger<ServicesWindowsController> logger, IServicesWindowsService servicesWindowsService)
        {
            _logger = logger;
            _servicesWindowsService = servicesWindowsService;
        }

        [HttpGet(Name = "services")]
        public async Task<IActionResult> GetServices()
        {
            return Ok();
        }
    }
}
