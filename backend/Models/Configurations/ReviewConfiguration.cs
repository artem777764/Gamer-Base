using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;


class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
       builder.HasKey(r => r.Id);

       builder.HasMany(r => r.Comments)
              .WithOne(c => c.Review)
              .HasForeignKey(c => c.ReviewId)
              .OnDelete(DeleteBehavior.Cascade);
       
       builder.HasOne(r => r.Game)
              .WithMany(g => g.Reviews)
              .HasForeignKey(r => r.GameId);
       
       builder.HasMany(r => r.VotesReview)
              .WithOne(vr => vr.Review)
              .HasForeignKey(vr => vr.ReviewId)
              .OnDelete(DeleteBehavior.Cascade);
       
       builder.HasOne(r => r.User)
              .WithMany(u => u.Reviews)
              .HasForeignKey(r => r.AuthorId);
       
       builder.HasMany(r => r.Notifications)
              .WithOne(n => n.Review)
              .HasForeignKey(n => n.ReviewId);
    }
}