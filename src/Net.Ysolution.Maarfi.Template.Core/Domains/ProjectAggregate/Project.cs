using Ardalis.GuardClauses;
using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate.Events;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;

public class Project  : BaseEntity<int>, IAggregateRoot
{
  public string Name { get; private set; }

  private List<ToDoItem> _items = new List<ToDoItem>();
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  public PriorityStatus Priority { get; }

  public Project(string name, PriorityStatus priority , DateTime created , Guid creator)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
    Priority = priority;
    Creator = creator;
    Created = created;
  }



  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem, nameof(newItem));
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    Events.Add(newItemAddedEvent);
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
