using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
{
    public void Configure(EntityTypeBuilder<NotificationEntity> builder)
    {
       builder.HasKey(n => n.Id);

       builder.HasOne(n => n.User)
              .WithMany(u => u.NotificationsUser)
              .HasForeignKey(n => n.UserId);
       
       builder.HasOne(n => n.Review)
              .WithMany(r => r.Notifications)
              .HasForeignKey(n => n.ReviewId);
       
       builder.HasOne(n => n.EntityType)
              .WithMany(et => et.Notifications)
              .HasForeignKey(n => n.EntityTypeId);
       
       builder.HasOne(n => n.InitiatorUser)
              .WithMany(iu => iu.NotificationsInitiatorUser)
              .HasForeignKey(n => n.InitiatorUserId);
    }
}