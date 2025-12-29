using GullyService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GullyService.Infrastructure.EntityConfiguration
{
    public class GullyConfiguration : IEntityTypeConfiguration<Gully>
    {
        public void Configure(EntityTypeBuilder<Gully> builder)
        {
            // Primary Key
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(g => g.Height).IsRequired();
            builder.Property(g => g.Width).IsRequired();
            builder.Property(g => g.PipeHeight).IsRequired();
            builder.Property(g => g.PipeDiameter).IsRequired();
            builder.Property(g => g.WaterHeight).IsRequired();
        }
    }
}
