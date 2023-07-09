using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;

namespace Net.Ysolution.Maarfi.Template.Core.Dto;

public class QueryUserResponse
{
  public List<UsersQueryDto> UserQueryResult { get; set; }

  public int TotalRecordCount { get; set; }

  public int newStart { get; set; }
}
