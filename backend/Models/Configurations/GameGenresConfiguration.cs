using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class GameGenresConfiguration : IEntityTypeConfiguration<GameGenresEntity>
{
    public void Configure(EntityTypeBuilder<GameGenresEntity> builder)
    {
        builder.HasKey(gg => new {gg.GameId, gg.GenreId});

        builder.HasOne(gg => gg.Genre)
               .WithMany(g => g.GameGenres)
               .HasForeignKey(gg => gg.GenreId);
        
        builder.HasOne(gg => gg.Game)
               .WithMany(g => g.GameGenres)
               .HasForeignKey(gg => gg.GameId);
    }
}