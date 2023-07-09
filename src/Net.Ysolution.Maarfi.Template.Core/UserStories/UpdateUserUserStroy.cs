
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
using Net.Ysolution.Maarfi.Template.Core.Dto;

namespace Net.Ysolution.Maarfi.Template.Core.Services;

public class UpdateUserUserStroy : IUserStory<UpdateUserRequest , UpdateUserResponse>
{
  private readonly IRepository<User> _userRepository;
  private readonly IRepository<Role> _roleRepository;
  private readonly IMapper _mapper;
  private readonly LocalizeService _localizeService;



  public UpdateUserUserStroy(IRepository<User> userRepository, IRepository<Role> roleRepository, IMapper mapper , LocalizeService localizeService)
  {
    _userRepository = userRepository;
    _roleRepository = roleRepository;
    _mapper = mapper;
    _localizeService = localizeService;
    _localizeService = localizeService;
  
  }
  public async Task<Result<UpdateUserResponse>> Execute(UpdateUserRequest requestDTO)
  {
    try
    {
      var user = _mapper.Map<User>(requestDTO);
      var validator = new UpdateUserValidator(_userRepository);
      var validation = validator.Validate(user);
      if (!validation.IsValid)
      {
        return Result<UpdateUserResponse>.Invalid(validation.AsErrors());
      }

       await _userRepository.UpdateAsync(user);

       return   Result<UpdateUserResponse>.Success(null);
    }
    catch (ArgumentException ex)
    {
     
      return Result<UpdateUserResponse>.Invalid(new List<ValidationError> { new ValidationError { ErrorMessage = _localizeService.GetLocalizedString(ex.Message.Substring(0, ex.Message.IndexOf("(")).Trim()) , Identifier = ex.ParamName , Severity = ValidationSeverity.Error  } });
    }
  }
}

