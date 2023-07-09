
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Shared.SharedKernal.Bases;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
public  class UserRole : ValueObject
{
 
  public string RoleId { get; set; }
  public Guid UserId { get; set; }

  public User User { get; set; }

  public UserRole(string roleId, Guid userId)
  {
    RoleId = roleId;
    UserId = userId;
  }
}
