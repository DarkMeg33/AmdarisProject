using AmdarisProject.Domain;

namespace AmdarisProject.DataAccess.Interfaces
{
    public interface IHostelRepository : IRepository<Hostel>
    {
        public Task<Hostel> GetHostelByIdWithIncludeAsync(int id);
        public Task<IList<Hostel>> GetAllHostelsWithIncludeAsync();
    }
}
