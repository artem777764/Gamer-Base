using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class PlatformConfiguration : IEntityTypeConfiguration<PlatformEntity>
{
    public void Configure(EntityTypeBuilder<PlatformEntity> builder)
    {
       builder.HasKey(p => p.Id);

       builder.HasMany(p => p.GamePlatforms)
              .WithOne(gp => gp.Platform)
              .HasForeignKey(gp => gp.PlatformId);
    }
}