using Ardalis.Specification;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Specifications;

public class UserRolesSpec : Specification<User> , ISingleResultSpecification
{
  public UserRolesSpec(Guid userId)
  {
    Query.Where(p=> p.Id == userId).Include(p => p.UserRoles);

  }
}
