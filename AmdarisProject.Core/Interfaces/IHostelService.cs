using AmdarisProject.Common.Dtos.Hostel;
using AmdarisProject.Common.Models;

namespace AmdarisProject.Core.Interfaces
{
    public interface IHostelService
    {
        Task<IList<HostelDto>> GetHostelsAsync();
        Task<PaginationResult<HostelDto>> GetPaginatedHostelsAsync(PaginationRequest paginationRequest);
        Task<HostelDto> GetHostelByIdAsync(int id);
        Task<HostelDto> CreateHostelAsync(HostelUpdateDto hostelUpdateDto);
        Task<HostelDto> UpdateHostelAsync(int id, HostelUpdateDto hostelUpdateDto);
        Task DeleteHostelAsync(int id);
    }
}
