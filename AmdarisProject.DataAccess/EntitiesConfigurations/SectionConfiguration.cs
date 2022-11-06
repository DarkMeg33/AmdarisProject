using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmdarisProject.DataAccess.EntitiesConfigurations
{
    internal class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Section)
                .HasForeignKey(fk => fk.SectionId);
        }
    }
}
