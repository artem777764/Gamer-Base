using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class GamePlatformsConfiguration : IEntityTypeConfiguration<GamePlatformsEntity>
{
    public void Configure(EntityTypeBuilder<GamePlatformsEntity> builder)
    {
        builder.HasKey(gp => new {gp.GameId, gp.PlatformId});

        builder.HasOne(gp => gp.Platform)
              .WithMany(p => p.GamePlatforms)
              .HasForeignKey(gp => gp.PlatformId);

        builder.HasOne(gp => gp.Game)
               .WithMany(g => g.GamePlatforms)
               .HasForeignKey(gp => gp.GameId);
    }
}