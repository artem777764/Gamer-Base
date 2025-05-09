using System.Runtime.CompilerServices;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations;

class UserDataConfiguration : IEntityTypeConfiguration<UserDataEntity>
{
    public void Configure(EntityTypeBuilder<UserDataEntity> builder)
    {
       builder.HasKey(ud => ud.Id);
    }
}