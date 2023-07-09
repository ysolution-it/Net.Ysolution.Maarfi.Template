using Ardalis.Specification.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(ModuleCommandContext dbContext) : base(dbContext)
  {
  }
}
