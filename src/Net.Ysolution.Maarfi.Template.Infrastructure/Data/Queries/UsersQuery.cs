
using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;


namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Queries;
public class UsersQuery : Query<UsersQueryDto, UsersQueryParam>
{
  public UsersQuery(ModuleReadContext dbContext) : base(dbContext)
  {
  }

  public override IQueryable<UsersQueryDto> Execute(UsersQueryParam param)
  {
    param.SearchText = "%" + param.SearchText + "%";   
     return _dbContext.UsersQueryDtos.FromSqlRaw(@"
            select* from(
            select Email, first_name FirstName, last_name LastName, count(1) RoleCount from com_users u
              inner join com_user_roles r on(u.id = r.user_id)
              where email like  {2}  or first_name like {2} or last_name like {2}
              group by Email , first_name  , last_name ) tb
              order by Email
             offset {0} rows
              FETCH NEXT {1} rows only", param.Start, param.Limit, param.SearchText);
  }
}


