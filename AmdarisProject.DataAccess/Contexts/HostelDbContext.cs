using System.Data;
using AmdarisProject.DataAccess.EntitiesConfigurations;
using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.DataAccess.Contexts
{
    public class HostelDbContext : DbContext
    {
        public HostelDbContext(DbContextOptions<HostelDbContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Floor> Floors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HostelConfiguration());
            modelBuilder.ApplyConfiguration(new FloorConfiguration());

            //TODO Create entities configurations
        }
    }
}
