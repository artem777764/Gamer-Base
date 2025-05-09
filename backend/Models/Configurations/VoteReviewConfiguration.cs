using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;


class VoteReviewConfiguration : IEntityTypeConfiguration<VoteReviewEntity>
{
    public void Configure(EntityTypeBuilder<VoteReviewEntity> builder)
    {
       builder.HasKey(vr => new {vr.UserId, vr.ReviewId});

       builder.HasOne(vr => vr.Review)
              .WithMany(r => r.VotesReview)
              .HasForeignKey(vr => vr.ReviewId);
       
       builder.HasOne(vr => vr.User)
              .WithMany(u => u.VotesReview)
              .HasForeignKey(vr => vr.UserId);
    }
}