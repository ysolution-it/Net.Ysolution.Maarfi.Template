
using Ardalis.Result;
using AutoMapper;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Validations;
using Net.Ysolution.Maarfi.Template.Core.Interfaces;
using Net.Ysolution.Maarfi.Template.Core.Services.Dto.AddUser;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Ardalis.Result.FluentValidation;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Specifications;
using Microsoft.Extensions.Localization;
using Net.Ysolution.Maarfi.Template.Core.Resources;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;

namespace Net.Ysolution.Maarfi.Template.Core.Services;

public class AddUserUserStroy : IUserStory<AddUserRequest , AddUserResponse>
{
  private readonly IRepository<User> _userRepository;
  private readonly IRepository<Role> _roleRepository;
  private readonly IMapper _mapper;
  private readonly LocalizeService _localizeService;



  public AddUserUserStroy(IRepository<User> userRepository, IRepository<Role> roleRepository, IMapper mapper , LocalizeService localizeService)
  {
    _userRepository = userRepository;
    _roleRepository = roleRepository;
    _mapper = mapper;
    _localizeService = localizeService;
    _localizeService = localizeService;
  
  }
  public async Task<Result<AddUserResponse>> Execute(AddUserRequest requestDTO)
  {
    try
    {
      var user = _mapper.Map<User>(requestDTO);

       foreach(var role in requestDTO.UserRoles)
      {
        user.AddUserRole(new UserRole ( role.RoleId,  user.Id));
      }
      var validator = new AddUserValidator(_userRepository , _roleRepository);
      var validation = validator.Validate(user);
      if (!validation.IsValid)
      {
        return Result<AddUserResponse>.Invalid(validation.AsErrors());
      }

      user = await _userRepository.AddAsync(user);


      return   Result<AddUserResponse>.Success(new AddUserResponse { Id = user.Id } , "Good");
    }
    catch (ArgumentException ex)
    {
     
      return Result<AddUserResponse>.Invalid(new List<ValidationError> { new ValidationError { ErrorMessage = _localizeService.GetLocalizedString(ex.Message.Substring(0, ex.Message.IndexOf("(")).Trim()) , Identifier = ex.ParamName , Severity = ValidationSeverity.Error  } });
    }
  }
}

