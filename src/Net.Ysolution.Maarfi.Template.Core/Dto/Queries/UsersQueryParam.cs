using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
public class UsersQueryParam
{
  public int Start { get; set; }
  public int Limit { get; set; }
  public string SearchText { get; set; }
}
