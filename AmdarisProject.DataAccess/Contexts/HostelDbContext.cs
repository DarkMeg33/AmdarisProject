using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.DataAccess.Contexts
{
    public class HostelDbContext : DbContext
    {
        public HostelDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hostel> Hostels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
