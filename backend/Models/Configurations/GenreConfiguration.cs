using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
       builder.HasKey(g => g.Id);

       builder.HasMany(g => g.GameGenres)
              .WithOne(gg => gg.Genre)
              .HasForeignKey(gg => gg.GenreId);
    }
}