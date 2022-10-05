using AmdarisProject.Common.Dtos;

namespace AmdarisProject.Core.Interfaces
{
    public interface IHostelService
    {
        Task<IList<HostelDto>> GetHostelsAsync();
        Task<HostelDto> GetHostelByIdAsync(int id);
        Task CreateHostelAsync(HostelDto hostel);
        Task UpdateHostelAsync(HostelDto hostel);
        Task DeleteHostelAsync(HostelDto hostel);
    }
}
