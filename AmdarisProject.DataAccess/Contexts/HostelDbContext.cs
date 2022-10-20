using AmdarisProject.DataAccess.EntitiesConfigurations;
using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.DataAccess.Contexts
{
    public class HostelDbContext : DbContext
    {
        public HostelDbContext(DbContextOptions<HostelDbContext> options) : base(options)
        {
            
        }

        public DbSet<Hostel> Hostels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HostelConfiguration());

            //TODO Create entities configurations
        }
    }
}
