using Microsoft.AspNetCore.Mvc;
using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using ServerCheckAgent.Resources;
using ServerCheckAgent.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesWindowsController : ControllerBase
    {
        private readonly ILogger<ServicesWindowsController> _logger;
        private readonly IServicesWindowsService _servicesWindowsService;

        public ServicesWindowsController(ILogger<ServicesWindowsController> logger, IServicesWindowsService servicesWindowsService)
        {
            _logger = logger;
            _servicesWindowsService = servicesWindowsService;
        }

        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            try
            {
                var services = await _servicesWindowsService.GetServices();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return BadRequest(new Models.Response()
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartService([FromQuery] string serviceName)
        {
            try
            {
                var serviceExist = await _servicesWindowsService.ServiceExist(serviceName);
                if (!serviceExist)
                    return BadRequest(new Response
                    {
                        Message = MessagesResponse.ServiceNotFound
                    });
                var result = await _servicesWindowsService.StartService(serviceName);
                if (!result)
                    return BadRequest(new
                    {
                        message = MessagesResponse.ErroStartService
                    });
                return Ok(new Response
                {
                    Message = MessagesResponse.StartWithSuccessfull
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Models.Response()
                {
                    Message= ex.Message
                });
            }
        }

        [HttpPost("stop")]
        public async Task<IActionResult> StopService([FromQuery] string serviceName)
        {
            try
            {
                var serviceExist = await _servicesWindowsService.ServiceExist(serviceName);
                if (!serviceExist)
                    return BadRequest(new Response
                    {
                        Message = MessagesResponse.ServiceNotFound
                    });
                var result = await _servicesWindowsService.StopService(serviceName);
                if (!result)
                    return BadRequest(new Response
                    {
                        Message = MessagesResponse.ErroStopService
                    });
                return Ok(new Response
                {
                    Message = MessagesResponse.StoppedWithSuccessfull
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Models.Response()
                {
                    Message = ex.Message
                });
            }
        }
    }
}
