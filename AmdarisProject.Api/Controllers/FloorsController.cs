using AmdarisProject.Common.Dtos.Floor;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmdarisProject.Api.Controllers
{
    [Route("api/floors")]
    public class FloorsController : AppControllerBase
    {
        //TODO Handle all ways, add new api exceptions
        private readonly IFloorService _floorService;

        public FloorsController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFloors()
        {
            var floors = await _floorService.GetFloorsAsync();

            return Ok(floors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFloor(int id)
        {
            var floor = await _floorService.GetFloorByIdAsync(id);

            return Ok(floor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFloor([FromBody] FloorUpdateDto floorUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var floor = await _floorService.CreateFloorAsync(floorUpdateDto);

            return CreatedAtAction(nameof(GetFloor), new { id = floor.Id }, floor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFloor(int id, [FromBody] FloorUpdateDto floorUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _floorService.UpdateFloorAsync(id, floorUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloor(int id)
        {
            await _floorService.DeleteFloorAsync(id);
            return NoContent();
        }
    }
}
