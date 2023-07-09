
using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Shared.Models.Dto;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Queries;
public class UserRolesByIdQuery : Query<UserRolesDto, UserRolesParam>
{
  public UserRolesByIdQuery(ModuleReadContext dbContext) : base(dbContext)
  {
  }

  public override IQueryable<UserRolesDto> Execute(UserRolesParam param)
  {
 
     return _dbContext.UserRolesDto.FromSqlRaw(@"
            select  r.id RoleId ,   r.arabic_name RoleArabicName 
              ,  r.english_name RoleEnglishName , u.id UserId from com_users u
              inner join com_user_roles ur on(u.id = ur.user_id) 
              inner join com_roles r on (ur.role_id = r.id )
              where u.id =  {0}
             ", param.Id);
  }
}


