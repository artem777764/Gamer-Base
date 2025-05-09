using System.Runtime.CompilerServices;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
       builder.HasKey(u => u.Id);

       builder.HasMany(u => u.VoteComments)
              .WithOne(vc => vc.User)
              .HasForeignKey(vc => vc.UserId);
       
       builder.HasMany(u => u.VotesReview)
              .WithOne(vr => vr.User)
              .HasForeignKey(vr => vr.UserId);
       
       builder.HasMany(u => u.Comments)
              .WithOne(c => c.User)
              .HasForeignKey(c => c.UserId);

       builder.HasMany(u => u.Reviews)
              .WithOne(r => r.User)
              .HasForeignKey(r => r.AuthorId);
       
       builder.HasMany(u => u.FavouriteGames)
              .WithOne(fg => fg.User)
              .HasForeignKey(fg => fg.UserId);
       
       builder.HasOne(u => u.UserData)
              .WithOne(ud => ud.User)
              .HasForeignKey<UserDataEntity>(ud => ud.Id);
       
       builder.HasMany(u => u.NotificationsUser)
              .WithOne(nu => nu.User)
              .HasForeignKey(n => n.UserId);
       
       builder.HasMany(u => u.NotificationsInitiatorUser)
              .WithOne(niu => niu.InitiatorUser)
              .HasForeignKey(niu => niu.InitiatorUserId);
    }
}