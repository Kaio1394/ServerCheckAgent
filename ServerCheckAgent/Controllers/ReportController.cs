using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Models.Response;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController: ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateReport()
        {
            try
            {
                var report = await _reportService.GenerateReportServer();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDefault
                {
                    Message = ex.Message
                });
            }
        }
    }
}
