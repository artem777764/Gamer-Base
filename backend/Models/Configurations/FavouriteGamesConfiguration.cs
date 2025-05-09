using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class FavouriteGamesConfiguration : IEntityTypeConfiguration<FavouriteGamesEntity>
{
    public void Configure(EntityTypeBuilder<FavouriteGamesEntity> builder)
    {
       builder.HasKey(fg => new {fg.UserId, fg.GameId});

       builder.HasOne(fg => fg.Game)
              .WithMany(g => g.FavouriteGames)
              .HasForeignKey(fg => fg.GameId);
       
       builder.HasOne(fg => fg.User)
              .WithMany(u => u.FavouriteGames)
              .HasForeignKey(fg => fg.UserId);
    }
}