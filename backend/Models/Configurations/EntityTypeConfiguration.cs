using System.Runtime.CompilerServices;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class EntityTypeConfiguration : IEntityTypeConfiguration<EntityType>
{
    public void Configure(EntityTypeBuilder<EntityType> builder)
    {
       builder.HasKey(et => et.Id);

       builder.HasMany(et => et.Notifications)
              .WithOne(n => n.EntityType)
              .HasForeignKey(n => n.EntityTypeId);
    }
}