using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Models.Response;
using ServerCheckAgent.Services;
using ServerCheckAgent.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace ServerCheckAgent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController: ControllerBase
    {
        private readonly IProcessService _ProcessService;
        public ProcessController(IProcessService ProcessService)
        {
            _ProcessService = ProcessService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListProcess()
        {
            try
            {
                var listProcess = await _ProcessService.GetListProcess();
                return Ok(listProcess);
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
