
using AutoMapper;
using AutoMapper.Extensions;
using Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Template.Core.Services.Dto.AddUser;
using Net.Ysolution.Maarfi.Shared.Models.Dto;


namespace Net.Ysolution.Maarfi.Template.Core;
public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {


    CreateMap<User, UserDto>();
    CreateMap<UserRole , UserRolesDto>();
    CreateMap<User, UserRolesDto>()
    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

    CreateMap<User, UserRolesDto>();
          //.ConvertUsing<EventLogConverter>();



    CreateMap<Role, UserRolesDto>()
      .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.RoleArabicName, opt => opt.MapFrom(src => src.ArabicName))
      .ForMember(dest => dest.RoleEnglishName, opt => opt.MapFrom(src => src.EnglishName));
    CreateMap<Module, ModuleDto>();

    //Add User
      CreateMap<AddUserRequest, User>().ForMember(dest => dest.UserRoles , opt => opt.Ignore()).IgnoreAllNonExisting();
     // CreateMap<AddUserRoleRequest, UserRole>().IgnoreAllNonExisting();
  }


  /*class EventLogConverter : ITypeConverter<User, IEnumerable<UserRolesDto>>
  {
   

    public IEnumerable<UserRolesDto> Convert(User source, IEnumerable<UserRolesDto> destination, ResolutionContext context)
    {
      
      
      foreach (var dto in source.Roles.Select(e => context.Mapper.Map<UserRolesDto>(e.Role)))
      {
        // map id and user id
        dto.UserId = source.Id;
        yield return dto;
      }
    }
  }*/
}
