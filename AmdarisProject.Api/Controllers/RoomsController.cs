using AmdarisProject.Api.Infrastructure.Configurations;
using AmdarisProject.Common.Dtos.Room;
using AmdarisProject.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AmdarisProject.Api.Controllers
{
    [Route("api/rooms")]
    public class RoomsController : AppControllerBase
    {
        //TODO Handle all ways, add new api exceptions
        private readonly IRoomService _roomService;
        private readonly FileManagerOptions _fileManagerOptions;

        public RoomsController(IRoomService roomService, IOptions<FileManagerOptions> fileManagerOptions)
        {
            _roomService = roomService;
            _fileManagerOptions = fileManagerOptions.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _roomService.GetRoomsAsync();

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomUpdateDto roomUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = await _roomService.CreateRoomAsync(roomUpdateDto);

            return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoomDto>> UpdateRoom(int id, [FromBody] RoomUpdateDto roomUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomDto = await _roomService.UpdateRoomAsync(id, roomUpdateDto);

            return roomDto;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id, _fileManagerOptions.Path);
            return NoContent();
        }
    }
}
