using System.Reflection;
using Autofac;
using Net.Ysolution.Maarfi.Template.Core;
using Net.Ysolution.Maarfi.Template.Core.Interfaces;
using Net.Ysolution.Maarfi.Template.Infrastructure.Data;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Template.Infrastructure.Data.Queries;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Shared.Models.Dto;

namespace Net.Ysolution.Maarfi.Template.Infrastructure;

public class InfrastructureModule : Module
{
  private readonly bool _isDevelopment = false;
  private readonly List<Assembly> _assemblies = new List<Assembly>();

  public InfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
  {
    _isDevelopment = isDevelopment;
    var coreAssembly = Assembly.GetAssembly(typeof(CoreModule)); // TODO: Replace "Project" with any type from your Core project
    var infrastructureAssembly = Assembly.GetAssembly(typeof(InfrastructureModule));
    if (coreAssembly != null)
    {
      _assemblies.Add(coreAssembly);
    }
    if (infrastructureAssembly != null)
    {
      _assemblies.Add(infrastructureAssembly);
    }
    if (callingAssembly != null)
    {
      _assemblies.Add(callingAssembly);
    }
  }

  protected override void Load(ContainerBuilder builder)
  {
    if (_isDevelopment)
    {
      RegisterDevelopmentOnlyDependencies(builder);
    }
    else
    {
      RegisterProductionOnlyDependencies(builder);
    }
    RegisterCommonDependencies(builder);
  }

  private void RegisterCommonDependencies(ContainerBuilder builder)
  {

    // Queries registration
    builder.RegisterType<UsersQuery>()
        .As(typeof(IQuery<UsersQueryDto, UsersQueryParam>))
        .InstancePerLifetimeScope();
    builder.RegisterType<UsersByIdQuery>()
       .As(typeof(IQuery<UserDto, UserByIdParam>))
       .InstancePerLifetimeScope();
    builder.RegisterType<UserRolesByIdQuery>()
       .As(typeof(IQuery<UserRolesDto, UserRolesParam>))
       .InstancePerLifetimeScope();
    builder.RegisterType<UsersByCredenialQuery>()
     .As(typeof(IQuery<UserDto, UserCredentialParam>))
     .InstancePerLifetimeScope();
    // Repository register
    builder.RegisterGeneric(typeof(EfRepository<>))
      .As(typeof(IRepository<>))
      .As(typeof(IReadRepository<>))
      .InstancePerLifetimeScope();

    builder
        .RegisterType<Mediator>()
        .As<IMediator>()
        .InstancePerLifetimeScope();

    builder.Register<ServiceFactory>(context =>
    {
      var c = context.Resolve<IComponentContext>();
      return t => c.Resolve(t);
    });

    var mediatrOpenTypes = new[]
    {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

    foreach (var mediatrOpenType in mediatrOpenTypes)
    {
      builder
      .RegisterAssemblyTypes(_assemblies.ToArray())
      .AsClosedTypesOf(mediatrOpenType)
      .AsImplementedInterfaces();
    }

    builder.RegisterType<EmailSender>().As<IEmailSender>()
        .InstancePerLifetimeScope();
  }

  private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
  {
    // TODO: Add development only services
  }

  private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
  {
    // TODO: Add production only services
  }
 

}
