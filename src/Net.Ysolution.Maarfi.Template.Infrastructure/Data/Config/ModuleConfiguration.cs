using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Shared.Infrastructure.Data;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Config;

public class ModuleConfiguration : BaseEntityConfiguration<Module, Guid>
{
  public override void Configure(EntityTypeBuilder<Module> builder)
  {
    _prefix = "com";
    base.Configure(builder);
    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();  
   
  }
}
