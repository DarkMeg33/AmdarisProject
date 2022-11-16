using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Common.Models;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmdarisProject.Api.Controllers
{
    [Route("api/hostels")]
    public class HostelsController : AppControllerBase
    {
        //TODO Handle all ways, add new api exceptions
        private readonly IHostelService _hostelService;

        public HostelsController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHostels()
        {
            var hostels = await _hostelService.GetHostelsAsync();

            return Ok(hostels);
        }

        [HttpPost("pagination")]
        public async Task<IActionResult> GetPagedHostel([FromBody] PaginationRequest paginationRequest)
        {
            var paginatedHostels = await _hostelService.GetPaginatedHostelsAsync(paginationRequest);
            return Ok(paginatedHostels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHostel(int id)
        {
            var hostel = await _hostelService.GetHostelByIdAsync(id);

            return Ok(hostel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHostel([FromBody] HostelUpdateDto hostelUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hostel = await _hostelService.CreateHostelAsync(hostelUpdateDto);

            return CreatedAtAction(nameof(GetHostel), new { id = hostel.Id }, hostel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHostel(int id, [FromBody] HostelUpdateDto hostelUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _hostelService.UpdateHostelAsync(id, hostelUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHostel(int id)
        {
            await _hostelService.DeleteHostelAsync(id);
            return NoContent();
        }
    }
}
