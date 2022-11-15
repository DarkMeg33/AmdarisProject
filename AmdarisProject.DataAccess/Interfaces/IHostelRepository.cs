using AmdarisProject.Common.Models;
using AmdarisProject.Domain;

namespace AmdarisProject.DataAccess.Interfaces
{
    public interface IHostelRepository : IRepository<Hostel>
    {
        Task<Hostel> GetHostelByIdWithIncludeAsync(int id);
        Task<IList<Hostel>> GetAllHostelsWithIncludeAsync();
        Task<PaginationResult<Hostel>> GetAllHostelsWithPaginate(PaginationRequest paginationRequest);
    }
}
