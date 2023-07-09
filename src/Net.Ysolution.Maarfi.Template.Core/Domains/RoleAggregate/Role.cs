
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;
namespace Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
public  class Role : BaseEntity<string>, IAggregateRoot
{
 
  public string ArabicName { get; set; }
  public string EnglishName { get; set; }

}
