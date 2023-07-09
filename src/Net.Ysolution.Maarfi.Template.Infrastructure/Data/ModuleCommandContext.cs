using MediatR;
using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Shared.Infrastructure.Data;
using Net.Ysolution.Maarfi.Shared.Models;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate;
namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data;

public class ModuleCommandContext : AppDbContext
{
  public ModuleCommandContext(DbContextOptions<ModuleCommandContext> options, IMediator? mediator, CurrentUserContextDto currentTenantDto) : base(options, mediator, currentTenantDto)
  {
  }



  public DbSet<User> Users => Set<User>();
  public DbSet<Role> Roles => Set<Role>();
  public DbSet<UserRole> UserRoles => Set<UserRole>();

  public DbSet<Module> Modules => Set<Module>();
  protected override string Schema => "dbo";

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }

 
}
