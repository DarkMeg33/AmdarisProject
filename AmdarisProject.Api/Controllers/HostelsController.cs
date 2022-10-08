﻿using AmdarisProject.Api.Controllers;
using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmdarisProject.Api.Controllersа
{
    [Route("api/hostels")]
    public class HostelsController : AppControllerBase
    {
        private readonly IHostelService _hostelService;

        public HostelsController(IHostelService hostelService)
        {
            _hostelService = hostelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHostels() //TODO Create pagination, filters 
        {
            var hostels = await _hostelService.GetHostelsAsync();

            return Ok(hostels);
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

            return CreatedAtAction(nameof(GetHostel), new { id = hostel.HostelNumber }, hostel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHostel(int id, [FromBody] HostelUpdateDto hostelUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hostelDto = await _hostelService.UpdateHostelAsync(id, hostelUpdateDto);

            if (hostelDto is null)
            {
                return Conflict();
            }

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