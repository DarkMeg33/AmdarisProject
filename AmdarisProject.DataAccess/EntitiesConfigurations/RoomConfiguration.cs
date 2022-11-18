using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmdarisProject.DataAccess.EntitiesConfigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder
                .HasMany(x => x.Tenants)
                .WithOne(x => x.Room)
                .HasForeignKey(fk => fk.RoomId);

            builder
                .HasOne(x => x.Image)
                .WithOne(i => i.Room)
                .HasForeignKey((Image image) => image.Id);
        }
    }
}
