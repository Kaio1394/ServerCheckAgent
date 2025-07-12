using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Services.Interfaces;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class EventViewerController : ControllerBase
    {
        private readonly ILogger<EventViewerController> _logger;
        private readonly IEventViewService _eventViewService;

        public EventViewerController(ILogger<EventViewerController> logger, IEventViewService eventViewService)
        {
            _logger = logger;
            _eventViewService = eventViewService;   
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListEventView(
            [FromQuery] string logName, 
            [FromQuery] string date, 
            [FromQuery] string limit)
        {
            try
            {
                var listEventView = await _eventViewService.GetEventViewList(logName, date, limit);
                return Ok(listEventView);
            }
            catch (Exception ex)
            {
                return BadRequest(new Models.Response()
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
