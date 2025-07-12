using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Services;
using ServerCheckAgent.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace ServerCheckAgent.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProccessController: ControllerBase
    {
        private readonly IProccessService _proccessService;
        public ProccessController(IProccessService proccessService)
        {
            _proccessService = proccessService;
        }

        [HttpGet("list/proccess")]
        public async Task<IActionResult> GetListproccess()
        {
            try
            {
                var listProccess = await _proccessService.GetListProcess();
                return Ok(listProccess);
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
