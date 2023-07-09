using Ardalis.Specification;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate.Specifications;

public class IncompleteItemsSpec : Specification<ToDoItem>
{
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}
