using Ardalis.Specification;
using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate.Specifications;

public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
        .Where(project => project.Id == projectId)
        .Include(project => project.Items);
  }
}
