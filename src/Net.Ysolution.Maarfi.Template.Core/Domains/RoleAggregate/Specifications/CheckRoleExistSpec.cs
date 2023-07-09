using Ardalis.Specification;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate.Specifications;
public class CheckRoleExistSpec : Specification<Role>, ISingleResultSpecification
{
  public CheckRoleExistSpec(string roleId)
  {
    Query.Where(p => p.Id == roleId);
  }

 

}
