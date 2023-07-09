using Ardalis.Result;
using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;

namespace Net.Ysolution.Maarfi.Template.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
