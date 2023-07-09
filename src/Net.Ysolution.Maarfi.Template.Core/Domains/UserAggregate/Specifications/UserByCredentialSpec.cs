using Ardalis.Specification;


namespace Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Specifications;

public class UserByCredentialSpec : Specification<User>, ISingleResultSpecification
{
  public UserByCredentialSpec(Guid userId , string password)
  {
    Query
        .Where(user => user.Id == userId && user.Password.ToLower() == password.ToLower());
  }
}
