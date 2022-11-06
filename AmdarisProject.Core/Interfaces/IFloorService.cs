using AmdarisProject.Common.Dtos.Floor;

namespace AmdarisProject.Core.Interfaces
{
    public interface IFloorService
    {
        Task<IList<FloorDto>> GetFloorsAsync();
        Task<FloorDto> GetFloorByIdAsync(int id);
        Task<FloorDto> CreateFloorAsync(FloorUpdateDto floorUpdateDto);
        Task<FloorDto> UpdateFloorAsync(int id, FloorUpdateDto floorUpdateDto);
        Task DeleteFloorAsync(int id);
    }
}
