
using Microsoft.EntityFrameworkCore;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Dapper;
using System.Data;

namespace Net.Ysolution.Maarfi.Template.Infrastructure.Data.Queries;
public class UsersByCredenialQuery : Query<UserDto, UserCredentialParam>
{
  public UsersByCredenialQuery(ModuleReadContext dbContext) : base(dbContext)
  {
  }

  public override IQueryable<UserDto> Execute(UserCredentialParam param)
  {

    return  _dbContext.Database.GetDbConnection().Query<UserDto , UserRolesDto , UserDto> (@"
 			  select u.id as Id, first_name FirstName, last_name LastName , u.username Username, Email , r.id as RoleId ,   r.arabic_name RoleArabicName 
              ,  r.english_name RoleEnglishName , u.id as UserId from com_users u
              inner join com_user_roles ur on(u.id = ur.user_id) 
              inner join com_roles r on (ur.role_id = r.id )
                where u.email like  @Email  and u.password like @Password 
             ", (s, a) => {

      if (s.UserRoles == null)
          s.UserRoles = new List<UserRolesDto>();
          s.UserRoles.Add(a);
      return s;
    } ,
             new { Email = param.UserName , Password = param.Password }, splitOn: "Id").AsQueryable();


   /* return _dbContext.UserDto.FromSqlRaw(@"
 			  select u.id as Id, first_name FirstName, last_name LastName , u.username Username, Email , r.id as RoleId ,   r.arabic_name RoleArabicName 
              ,  r.english_name RoleEnglishName , u.id as UserId from com_users u
              inner join com_user_roles ur on(u.id = ur.user_id) 
              inner join com_roles r on (ur.role_id = r.id )
                where u.email like  {0}  and u.password like {1} 
			 
             ", param.UserName, param.Password);*/
  }
}


