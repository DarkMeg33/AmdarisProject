using AmdarisProject.Common.Dtos;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmdarisProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        private readonly IHostelService _hostelService;

        public HostelsController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hostels = await _hostelService.GetHostelsAsync();

            return Ok(hostels);
        }
    }
}
