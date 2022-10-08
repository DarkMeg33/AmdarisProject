using AmdarisProject.Common.Dtos.Hostel;

namespace AmdarisProject.Core.Interfaces
{
    public interface IHostelService
    {
        Task<IList<HostelDto>> GetHostelsAsync();
        Task<HostelDto> GetHostelByIdAsync(int id);
        Task<HostelDto> CreateHostelAsync(HostelUpdateDto hostelUpdateDto);
        Task<HostelDto> UpdateHostelAsync(int id, HostelUpdateDto hostelUpdateDto);
        Task DeleteHostelAsync(int id);
    }
}
