using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
public interface IQuery<Q,P>
{
  IQueryable<Q> Execute(P param);
}
