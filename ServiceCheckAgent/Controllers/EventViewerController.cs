using Microsoft.AspNetCore.Mvc;

namespace ServiceCheckAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventViewerController : ControllerBase
    {
        private readonly ILogger<EventViewerController> _logger;

        public EventViewerController(ILogger<EventViewerController> logger)
        {
            _logger = logger;
        }
    }
}
