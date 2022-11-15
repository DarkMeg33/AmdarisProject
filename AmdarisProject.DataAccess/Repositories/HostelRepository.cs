using AmdarisProject.Common.Models;
using AmdarisProject.DataAccess.Extensions;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.DataAccess.Repositories
{
    public class HostelRepository : EFCoreRepository<Hostel>, IHostelRepository
    {
        public HostelRepository(DbContext context) : base(context)
        {
        }

        public async Task<Hostel> GetHostelByIdWithIncludeAsync(int id)
        {
            var query = IncludeAll();
            return await query.FirstOrDefaultAsync(hostel => hostel.Id == id);
        }

        public async Task<IList<Hostel>> GetAllHostelsWithIncludeAsync()
        {
            var query = IncludeAll();
            return await query.ToListAsync();
        }

        public async Task<PaginationResult<Hostel>> GetAllHostelsWithPaginate(PaginationRequest paginationRequest)
        {
            var query = IncludeAll();
            return await query.GetPaginationResultAsync(paginationRequest);
        }

        public IQueryable<Hostel> IncludeAll()
        {
            return _dbSet
                .Include(hostel => hostel.Floors)
                .ThenInclude(floor => floor.Sections)
                .ThenInclude(section => section.Rooms);
        }
    }
}
