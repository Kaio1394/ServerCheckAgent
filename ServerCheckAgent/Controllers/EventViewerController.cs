using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("[controller]/api")]
    public class EventViewerController : ControllerBase
    {
        private readonly ILogger<EventViewerController> _logger;

        public EventViewerController(ILogger<EventViewerController> logger)
        {
            _logger = logger;
        }
    }
}
