using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Shared.Infrastructure.Data;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Config;

public class UserRoleConfiguration : ValueObjectConfiguration<UserRole>
{
  public override void Configure(EntityTypeBuilder<UserRole> builder)
  {
    _prefix = "com";
    base.Configure(builder);
    builder.HasKey(p => new { p.UserId , p.RoleId });
    builder.HasOne<User>(sc => sc.User)
    .WithMany(s => s.UserRoles)
    .HasForeignKey(sc => sc.UserId);

  
     

  }
}
