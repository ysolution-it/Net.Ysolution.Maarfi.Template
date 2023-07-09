using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.Infrastructure.Data;
namespace Net.Ysolution.Maarfi.Template.Web;

public static class SeedData
{
  public static readonly Project TestProject1 = new Project("Test Project", PriorityStatus.Backlog , DateTime.Now , Guid.NewGuid());
  
  public static readonly ToDoItem ToDoItem1 = new ToDoItem
  {
    Title = "Get Sample Working",
    Description = "Try to get the sample to build.",
    Created = DateTime.Now,
    Creator = Guid.NewGuid()
  };
  
  public static readonly ToDoItem ToDoItem2 = new ToDoItem
  {
    Title = "Review Solution",
    Description = "Review the different projects in the solution and how they relate to one another.",
    Created = DateTime.Now,
    Creator = Guid.NewGuid()
  };
  public static readonly ToDoItem ToDoItem3 = new ToDoItem
  {
    Title = "Run and Review Tests",
    Description = "Make sure all the tests run and review what they are doing.",
    Created = DateTime.Now,
    Creator = Guid.NewGuid()
  };

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new ModuleCommandContext(
        serviceProvider.GetRequiredService<DbContextOptions<ModuleCommandContext>>(), null, new Shared.Models.Dto.CurrentUserContextDto { TenantId = Guid.NewGuid() }))
    {
     

      PopulateTestData(dbContext);


    }
  }
  public static void PopulateTestData(ModuleCommandContext dbContext)
  {
    

    dbContext.SaveChanges();
  }
}
