using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.VotesComment)
               .WithOne(vc => vc.Comment)
               .HasForeignKey(vc => vc.CommentId)
               .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId);
        
        builder.HasOne(c => c.Review)
               .WithMany(r => r.Comments)
               .HasForeignKey(c => c.ReviewId);
    }
}