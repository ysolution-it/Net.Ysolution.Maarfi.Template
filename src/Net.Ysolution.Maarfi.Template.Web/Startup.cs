using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.Core;
using Net.Ysolution.Maarfi.Template.Infrastructure;
using Net.Ysolution.Maarfi.Template.Infrastructure.Data;
using Net.Ysolution.Maarfi.Shared.Infrastructure.Extensions;
namespace Net.Ysolution.Maarfi.Template.Web;
using Autofac;
using AutoMapper;
using Net.Ysolution.Maarfi.Template.Web.Resources;

public static class Startup
{
  public static void RegisterAdminModule(this WebApplicationBuilder builder , string connectionString  = ""  )
  {
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
     
      containerBuilder.RegisterModule(new InfrastructureModule(builder.Environment.EnvironmentName == "Development"));
      containerBuilder.RegisterModule(new CoreModule());
      containerBuilder.RegisterType<LocalizeService>().SingleInstance();

    });
    builder.Services.AddDatabaseContext<ModuleCommandContext>(connectionString);
    builder.Services.AddDatabaseContext<ModuleReadContext>(connectionString);
    builder.Services.AddAutoMapper(typeof(Startup) , typeof(CoreModule) , typeof(InfrastructureModule));
   
  }
 

  public static void SeedCoursesData(this IServiceProvider serviceProvider)
  {


    try
    {
      var context = serviceProvider.GetRequiredService<ModuleCommandContext>();
      context.Database.Migrate();
      context.Database.EnsureCreated();
      SeedData.Initialize(serviceProvider);
    }
    catch (Exception ex)
    {
      var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
      logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }

  }
}

