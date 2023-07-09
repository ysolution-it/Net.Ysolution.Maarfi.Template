using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Shared.Models.Dto;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data;

public class ModuleReadContext : DbContext
{
  private readonly CurrentUserContextDto _currentTenantDto;

  public ModuleReadContext(DbContextOptions<ModuleReadContext> options,
                           CurrentUserContextDto currentTenantDto) : base(options)
  {
    _currentTenantDto = currentTenantDto ?? throw new ArgumentNullException(nameof(currentTenantDto));
  }

  public DbSet<UsersQueryDto> UsersQueryDtos => Set<UsersQueryDto>();
  public DbSet<UserDto> UserDto => Set<UserDto>();

  public DbSet<UserRolesDto> UserRolesDto => Set<UserRolesDto>();
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<UsersQueryDto>().HasNoKey().ToView("view_UsersQueryDto");
    modelBuilder.Entity<UserDto>().HasNoKey().ToView("view_UserDto");
    modelBuilder.Entity<UserRolesDto>().HasNoKey().ToView("view_UserRolesDto");
    modelBuilder.Entity<UserDto>().Ignore(p => p.JwtToken);
    modelBuilder.Entity<UserDto>().Ignore(p => p.Password);
    modelBuilder.Entity<UserDto>().Ignore(p => p.RefreshToken);
    //modelBuilder.Entity<UserDto>().HasMany(p => p.UserRoles).WithOne()/*.HasPrincipalKey(p=> p.Id)*/.HasForeignKey(p => p.UserId);
  }
}


