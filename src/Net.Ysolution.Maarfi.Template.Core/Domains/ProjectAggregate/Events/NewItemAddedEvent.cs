using Net.Ysolution.Maarfi.Shared.Models;
using Net.Ysolution.Maarfi.Shared.SharedKernel;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate.Events;

public class NewItemAddedEvent : BaseDomainEvent
{
  public ToDoItem NewItem { get; set; }
  public Project Project { get; set; }

  public NewItemAddedEvent(Project project,
      ToDoItem newItem)
  {
    Project = project;
    NewItem = newItem;
  }
}
