using AmdarisProject.DataAccess.EntitiesConfigurations;
using AmdarisProject.DataAccess.SchemaConstants;
using AmdarisProject.Domain;
using AmdarisProject.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.DataAccess.Contexts
{
    public class HostelDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public HostelDbContext(DbContextOptions<HostelDbContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HostelConfiguration());
            modelBuilder.ApplyConfiguration(new FloorConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());

            //TODO Create entities configurations

            ApplyIdentityConfiguration(modelBuilder);
        }

        public void ApplyIdentityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", IdentitySchema.Identity);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", IdentitySchema.Identity);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", IdentitySchema.Identity);
            modelBuilder.Entity<UserToken>().ToTable("UserTokens", IdentitySchema.Identity);
            modelBuilder.Entity<Role>().ToTable("Roles", IdentitySchema.Identity);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", IdentitySchema.Identity);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", IdentitySchema.Identity);
        }
    }
}
