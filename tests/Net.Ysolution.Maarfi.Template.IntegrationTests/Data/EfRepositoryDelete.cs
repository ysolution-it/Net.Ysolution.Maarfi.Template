using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;
using Xunit;

namespace Net.Ysolution.Maarfi.Template.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a project
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var project = new Project(initialName, PriorityStatus.Backlog, DateTime.Now, Guid.NewGuid());
    await repository.AddAsync(project);

    // delete the item
    await repository.DeleteAsync(project);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        project => project.Name == initialName);
  }
}
