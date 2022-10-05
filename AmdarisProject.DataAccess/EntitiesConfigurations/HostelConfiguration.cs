using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmdarisProject.DataAccess.EntitiesConfigurations
{
    internal class HostelConfiguration : IEntityTypeConfiguration<Hostel>
    {
        public void Configure(EntityTypeBuilder<Hostel> builder)
        {
            builder
                .HasMany(e => e.Floors)
                .WithOne(e => e.Hostel)
                .HasForeignKey(fk => fk.HostelId);
        }
    }
}
