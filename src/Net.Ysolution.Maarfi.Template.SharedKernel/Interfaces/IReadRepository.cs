using Ardalis.Specification;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
