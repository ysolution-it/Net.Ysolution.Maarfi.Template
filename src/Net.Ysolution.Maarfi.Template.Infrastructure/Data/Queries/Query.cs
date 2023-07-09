using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Queries;
public abstract class Query<Q, P> : IQuery<Q, P>
{
  protected readonly ModuleReadContext _dbContext;

  public Query(ModuleReadContext dbContext)
  {
    _dbContext = dbContext;
  }

  public abstract IQueryable<Q> Execute(P param);
 
}
