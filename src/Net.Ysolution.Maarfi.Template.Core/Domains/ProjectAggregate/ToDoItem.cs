using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate.Events;
using Net.Ysolution.Maarfi.Template.SharedKernel;
using Net.Ysolution.Maarfi.Shared.Models;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;

public class ToDoItem : BaseEntity<int>
{
  public string Title { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public bool IsDone { get; private set; }

  public void MarkComplete()
  {
    if (!IsDone)
    {
      IsDone = true;

      Events.Add(new ToDoItemCompletedEvent(this));
    }
  }

  public override string ToString()
  {
    string status = IsDone ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {Title} - {Description}";
  }
}
