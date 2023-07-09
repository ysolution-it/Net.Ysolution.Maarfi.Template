using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;
using Net.Ysolution.Maarfi.Template.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Net.Ysolution.Maarfi.Template.IntegrationTests.Data;

public abstract class BaseEfRepoTestFixture
{
  protected ModuleCommandContext _commandDbContext;
  protected ModuleReadContext _readDbContext;
  protected BaseEfRepoTestFixture()
  {
    var moduleCommandContextOptions = CreateModuleCommandContextOptions();
    var moduleReadContextOptions = CreateModuleReadContextOptions();
    var mockMediator = new Mock<IMediator>();

    _commandDbContext = new ModuleCommandContext(moduleCommandContextOptions, mockMediator.Object , new Shared.Models.Dto.CurrentUserContextDto { TenantId = Guid.NewGuid()});
    _readDbContext = new ModuleReadContext(moduleReadContextOptions, new Shared.Models.Dto.CurrentUserContextDto { TenantId = Guid.NewGuid() });
  }

  protected static DbContextOptions<ModuleCommandContext> CreateModuleCommandContextOptions()
  {
    // Create a fresh service provider, and therefore a fresh
    // InMemory database instance.
    var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<ModuleCommandContext>();
    builder.UseInMemoryDatabase("cleanarchitecture")
           .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

  protected static DbContextOptions<ModuleReadContext> CreateModuleReadContextOptions()
  {
    // Create a fresh service provider, and therefore a fresh
    // InMemory database instance.
    var serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    // Create a new options instance telling the context to use an
    // InMemory database and the new service provider.
    var builder = new DbContextOptionsBuilder<ModuleReadContext>();
    builder.UseInMemoryDatabase("cleanarchitecture")
           .UseInternalServiceProvider(serviceProvider);

    return builder.Options;
  }

  protected EfRepository<Project> GetRepository()
  {
    return new EfRepository<Project>(_commandDbContext);
  }
}
