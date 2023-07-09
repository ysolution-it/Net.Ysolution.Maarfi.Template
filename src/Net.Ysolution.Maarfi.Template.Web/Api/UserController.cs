using Microsoft.AspNetCore.Mvc;
using Net.Ysolution.Maarfi.Template.Core.Interfaces;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using AutoMapper;
using Net.Ysolution.Maarfi.Template.Core.Services.Dto.AddUser;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Net.Ysolution.Maarfi.Template.Web.Resources;
using Net.Ysolution.Maarfi.Template.Core.Services;
using Ardalis.Result;
using Net.Ysolution.Maarfi.Template.Core.Dto;
using Net.Ysolution.Maarfi.Shared.Core.Commands;
using MediatR;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;

namespace Net.Ysolution.Maarfi.Template.Web.Api;

public class UserController : BaseApiController
{
 
  private readonly IMapper _mapper;
  private readonly LocalizeService _locService;
  private readonly IUserStory<AddUserRequest, AddUserResponse> _addUserUserStory;
  private readonly IUserStory<QueryUserRequest, QueryUserResponse> _queryUserUserStory;
  private readonly IUserStory<UpdateUserRequest, UpdateUserResponse> _updateUserUserStory;
  private readonly IQuery<UserDto, UserByIdParam> _userByIdQuery;
  private readonly ILogger<UserController> _logger;
  private readonly IMediator _mediator;

  public UserController( IMapper mapper , LocalizeService locService , IUserStory<AddUserRequest, AddUserResponse> addUserUserStory ,
    IUserStory<QueryUserRequest, QueryUserResponse> queryUserUserStory ,
     IUserStory<UpdateUserRequest, UpdateUserResponse> updateUserUserStory , IQuery<UserDto, UserByIdParam> userByIdQuery ,
    ILogger<UserController> logger , IMediator mediator) 
  {
    
    _mapper = mapper;
    _locService = locService;
    _addUserUserStory = addUserUserStory;
    _queryUserUserStory = queryUserUserStory;
    _updateUserUserStory = updateUserUserStory;
    _userByIdQuery = userByIdQuery;
    _logger = logger;
    _mediator = mediator;
  }



  

  //[TranslateResultToActionResult]
  [HttpPost("AddUser")]
  public async Task<Result<AddUserResponse>> AddUser(AddUserRequest addUserRequest)
  {
    try
    {
    
      var result = await _addUserUserStory.Execute(addUserRequest);
      
      return result;
    }
   
    catch (Exception ex)
    {
      
      return Result.Invalid(new List<ValidationError> { new ValidationError { ErrorMessage = ex.Message , Severity = ValidationSeverity.Error} });
    }
  }
  [HttpPost("UpdateUser")]
  public async Task<Result<UpdateUserResponse>> UpdateUser(UpdateUserRequest updateUserRequest)
  {
   
     
       return  await _updateUserUserStory.Execute(updateUserRequest);
   
   
  }
  [HttpGet("GetUsers/{start}/{limit}/{searchText}")]
  public async Task<Result<QueryUserResponse>> GetUsers([FromRoute] int start , int limit , string searchText)
  {
    try
    {
      return await _queryUserUserStory.Execute(new QueryUserRequest { Start = start , Limit = limit , SearchText = searchText} );
    }
    catch(Exception ex)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
      _logger.LogError(ex.Message);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
      return Result.Error(_locService.GetLocalizedString("CallAdmin"));
    }
   
  }
  [HttpGet("GetUserById/{id}/")]
  public async Task<Result<List<UserDto>>> GetUserById([FromRoute] Guid id)
  {
    try
    {
      return await Task.FromResult( Result<List<UserDto>>.Success( _userByIdQuery.Execute(new UserByIdParam { Id = id }).ToList()));
    }
    catch (Exception ex)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
      _logger.LogError(ex.Message);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
      return Result.Error(_locService.GetLocalizedString("CallAdmin"));
    }

  }
  [HttpPost("authenticate")]
  public UserDto Authenticate()
  {

    var user =  _mediator.Send(new CheckUserCredentialCommand { UserName = "k.fathy@ysolution.net", Password = "string" }).Result;
    return user;
  }
}
