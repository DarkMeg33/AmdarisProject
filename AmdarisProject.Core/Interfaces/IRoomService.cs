using AmdarisProject.Common.Dtos.Room;

namespace AmdarisProject.Core.Interfaces
{
    public interface IRoomService
    {
        Task<IList<RoomDto>> GetRoomsAsync();
        Task<RoomDto> GetRoomByIdAsync(int id);
        Task<RoomDto> CreateRoomAsync(RoomUpdateDto roomUpdateDto);
        Task<RoomDto> UpdateRoomAsync(int id, RoomUpdateDto roomUpdateDto);
        Task DeleteRoomAsync(int id);
    }
}
