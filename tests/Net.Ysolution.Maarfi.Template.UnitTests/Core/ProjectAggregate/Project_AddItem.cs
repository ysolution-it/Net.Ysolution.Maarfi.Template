using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;
using Xunit;

namespace Net.Ysolution.Maarfi.Template.UnitTests.Core.ProjectAggregate;

public class Project_AddItem
{
  private Project _testProject = new Project("some name", PriorityStatus.Backlog, DateTime.Now, Guid.NewGuid());

  [Fact]
  public void AddsItemToItems()
  {
    var _testItem = new ToDoItem
    {
      Title = "title",
      Description = "description"
    };

    _testProject.AddItem(_testItem);

    Assert.Contains(_testItem, _testProject.Items);
  }

  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
#nullable disable
    Action action = () => _testProject.AddItem(null);
#nullable enable

    var ex = Assert.Throws<ArgumentNullException>(action);
    Assert.Equal("newItem", ex.ParamName);
  }
}
