using Ardalis.Specification;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
