using Ardalis.Specification;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Specifications;

public class CheckUserUniqSpec : Specification<User> , ISingleResultSpecification
{
  public CheckUserUniqSpec(User user)
  {
    Query.Where(p=> p.Email == user.Email);

  }

 
}
