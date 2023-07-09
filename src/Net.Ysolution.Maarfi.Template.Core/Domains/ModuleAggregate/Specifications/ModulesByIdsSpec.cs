using Ardalis.Specification;
using Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate.Specifications;

public class ModulesByIdsSpec : Specification<Module>
{
  public ModulesByIdsSpec(List<Guid> modulesIds)
  {
    Query.Where(item => modulesIds.Contains( item.Id) );
  }
}
