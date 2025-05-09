using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class DeveloperConfiguration : IEntityTypeConfiguration<DeveloperEntity>
{
    public void Configure(EntityTypeBuilder<DeveloperEntity> builder)
    {
        builder.HasKey(d => d.Id);

        builder.HasMany(d => d.Games)
               .WithOne(g => g.Developer)
               .HasForeignKey(g => g.DeveloperId);
    }
}