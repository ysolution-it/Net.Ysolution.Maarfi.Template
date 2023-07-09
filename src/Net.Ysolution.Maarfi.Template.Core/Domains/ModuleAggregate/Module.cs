
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate;
public class Module : BaseEntity<Guid> ,  IAggregateRoot
{

    public string Name { get; set; }
}
