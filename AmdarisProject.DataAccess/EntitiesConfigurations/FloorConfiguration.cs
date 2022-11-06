using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmdarisProject.DataAccess.EntitiesConfigurations
{
    internal class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder
                .HasMany(x => x.Sections)
                .WithOne(x => x.Floor)
                .HasForeignKey(fk => fk.FloorId);
        }
    }
}
