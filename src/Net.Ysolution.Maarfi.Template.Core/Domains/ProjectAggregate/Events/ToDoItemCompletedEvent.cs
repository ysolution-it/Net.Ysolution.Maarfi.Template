using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;
using Net.Ysolution.Maarfi.Template.SharedKernel;
using Net.Ysolution.Maarfi.Shared.Models;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate.Events;

public class ToDoItemCompletedEvent : BaseDomainEvent
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
