using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Shared.Infrastructure.Data;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Config;

public class UserConfiguration : BaseEntityConfiguration<User, Guid>
{
  public override void Configure(EntityTypeBuilder<User> builder)
  {
    _prefix = "com";
    base.Configure(builder);

    builder.Property(p => p.FirstName)
        .HasMaxLength(100)
        .IsRequired();
    builder.Property(p => p.LastName)
     .HasMaxLength(100)
     .IsRequired();
    builder.Property(p => p.Email)
  .HasMaxLength(100)
  .IsRequired();



  
  }
}
