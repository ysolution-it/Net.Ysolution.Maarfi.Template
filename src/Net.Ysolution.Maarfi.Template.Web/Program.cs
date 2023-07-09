using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using Net.Ysolution.Maarfi.Template.Web;
using Autofac.Configuration;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using FluentValidation.AspNetCore;
using Newtonsoft.Json.Converters;
using NJsonSchema.Infrastructure;
using Ardalis.Result;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  //Configuration.GetConnectionString("DefaultConnection");


// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});
// Register the ConfigurationModule with Autofac.



builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  var configurationModule = new ConfigurationModule(builder.Configuration);
  containerBuilder.RegisterModule(configurationModule);
}
);





// Add services to the container.
builder.Services.AddLocalization(options =>
{
  options.ResourcesPath = "Resources";
});

builder.Services.AddControllers().AddJsonOptions(x =>
{
  x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

}).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>()).AddNewtonsoftJson(jsonOptions =>
{
  jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
  var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
  jsonResolver.IgnoreProperty(typeof(Result<Result>), "ValueType");
  jsonOptions.SerializerSettings.ContractResolver = jsonResolver;

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.CustomSchemaIds(type => type.ToString());
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddScoped<CurrentUserContextDto>();
builder.RegisterAdminModule(connectionString);
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
  var supportedCultures = new[]
  {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG")
        };

  options.SupportedCultures = supportedCultures;
  options.SupportedUICultures = supportedCultures;

  options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
  {
    var languages = context.Request.Headers["Accept-Language"].ToString();
    var currentLanguage = languages.Split(',').FirstOrDefault();
    var defaultLanguage = string.IsNullOrEmpty(currentLanguage) ? "en" : currentLanguage;

    if (!supportedCultures.Where(s => s.Name.Equals(defaultLanguage)).Any())
    {
      defaultLanguage = "en-US";
    }

    return Task.FromResult(new ProviderCultureResult(defaultLanguage, defaultLanguage));
  }));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware();
}
//AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
//{
//    app.Logger.LogError(eventArgs.Exception.ToString());
//};




app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();




app.Use((context, next) =>
{

  if (context.Request.HttpContext.User.Claims.Where(c => c.Type == "user_id").Count() > 0)
  {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    context.RequestServices.GetService<CurrentUserContextDto>().UserName = context.Request.HttpContext.User.Identity.Name;

    context.RequestServices.GetService<CurrentUserContextDto>().UserId = Guid.Parse(context.Request.HttpContext.User.Claims.Where(c => c.Type == "user_id").FirstOrDefault().Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
  }

  return next.Invoke();
});

app.UseSerilogRequestLogging(options =>
{
  options.EnrichDiagnosticContext = (IDiagnosticContext diagnosticContext, HttpContext httpContext) =>
  {
    diagnosticContext.Set("ClientContext", "khaled");
  };
});
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
if (localizationOptions != null) app.UseRequestLocalization(localizationOptions.Value);
app.Run();


