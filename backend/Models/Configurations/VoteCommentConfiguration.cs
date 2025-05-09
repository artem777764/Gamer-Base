using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class VoteCommentConfiguration : IEntityTypeConfiguration<VoteCommentEntity>
{
    public void Configure(EntityTypeBuilder<VoteCommentEntity> builder)
    {
       builder.HasKey(vc => new {vc.UserId, vc.CommentId});

       builder.HasOne(vc => vc.User)
              .WithMany(u => u.VoteComments)
              .HasForeignKey(vc => vc.UserId);
       
       builder.HasOne(vc => vc.Comment)
              .WithMany(c => c.VotesComment)
              .HasForeignKey(vc => vc.CommentId);
    }
}