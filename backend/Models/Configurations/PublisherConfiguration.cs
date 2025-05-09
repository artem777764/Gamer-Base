using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class PublisherConfiguration : IEntityTypeConfiguration<PublisherEntity>
{
    public void Configure(EntityTypeBuilder<PublisherEntity> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.Games)
               .WithOne(g => g.Publisher)
               .HasForeignKey(g => g.PublisherId);
    }
}