using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class GameConfiguration : IEntityTypeConfiguration<GameEntity>
{
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
       builder.HasKey(g => g.Id);

       builder.HasMany(g => g.Reviews)
              .WithOne(r => r.Game)
              .HasForeignKey(r => r.GameId);
       
       builder.HasMany(g => g.GamePlatforms)
              .WithOne(gp => gp.Game)
              .HasForeignKey(gp => gp.GameId);
       
       builder.HasMany(g => g.GameGenres)
              .WithOne(gg => gg.Game)
              .HasForeignKey(gg => gg.GameId);
       
       builder.HasOne(g => g.Developer)
              .WithMany(d => d.Games)
              .HasForeignKey(g => g.DeveloperId);
       
       builder.HasOne(g => g.Publisher)
              .WithMany(p => p.Games)
              .HasForeignKey(g => g.PublisherId);
       
       builder.HasMany(g => g.FavouriteGames)
              .WithOne(fg => fg.Game)
              .HasForeignKey(fg => fg.GameId);
    }
}