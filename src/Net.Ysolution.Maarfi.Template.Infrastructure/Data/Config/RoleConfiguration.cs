using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Shared.Infrastructure.Data;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Config;

public class RoleConfiguration : BaseEntityConfiguration<Role, string>
{
  public override void Configure(EntityTypeBuilder<Role> builder)
  {
    _prefix = "com";
    base.Configure(builder);

    builder.Property(p => p.ArabicName)
        .HasMaxLength(100)
        .IsRequired();
    builder.Property(p => p.EnglishName)
     .HasMaxLength(100)
     .IsRequired();



  }
}
