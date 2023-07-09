using System.ComponentModel.DataAnnotations;
using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;

namespace Net.Ysolution.Maarfi.Template.Web.ApiModels;

// ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
public class ToDoItemDTO
{
  public int Id { get; set; }
  [Required]
  public string? Title { get; set; }
  public string? Description { get; set; }
  public bool IsDone { get; private set; }

  public static ToDoItemDTO FromToDoItem(ToDoItem item)
  {
    return new ToDoItemDTO()
    {
      Id = item.Id,
      Title = item.Title,
      Description = item.Description,
      IsDone = item.IsDone
    };
  }
}
