
using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Shared.Models.Dto;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Queries;
public class UsersByIdQuery : Query<UserDto, UserByIdParam>
{
  public UsersByIdQuery(ModuleReadContext dbContext) : base(dbContext)
  {
  }

  public override IQueryable<UserDto> Execute(UserByIdParam param)
  {

    

    return _dbContext.UserDto.FromSqlRaw(@"
            select u.id  Id, first_name FirstName, last_name LastName , u.username Username, Email , r.id RoleId ,   r.arabic_name RoleArabicName 
              ,  r.english_name RoleEnglishName , u.id UserId from com_users u
              inner join com_user_roles ur on(u.id = ur.user_id) 
              inner join com_roles r on (ur.role_id = r.id )
              where u.id =  {0}
             ", param.Id).Include(p=> p.UserRoles).AsSingleQuery();
  }
}


