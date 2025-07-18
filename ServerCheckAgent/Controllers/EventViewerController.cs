using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models.Response;
using ServerCheckAgent.Services.Interfaces;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Eventing.Reader;

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
            [FromQuery] string entryType,
            [FromQuery] string logName, 
            [FromQuery] string date, 
            [FromQuery] string limit)
        {
            try
            {
                var listEventView = await _eventViewService.GetEventViewList(entryType, logName, date, limit);

                return Ok(listEventView);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDefault()
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
