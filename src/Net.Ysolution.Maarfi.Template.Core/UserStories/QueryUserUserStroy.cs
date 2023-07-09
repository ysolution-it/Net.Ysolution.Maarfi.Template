
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
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;

namespace Net.Ysolution.Maarfi.Template.Core.Services;

public class QueryUserUserStroy : IUserStory<QueryUserRequest, QueryUserResponse>
{
  private readonly IQuery<UsersQueryDto, UsersQueryParam> _query;
  private readonly IMapper _mapper;
  private readonly LocalizeService _localizeService;



  public QueryUserUserStroy(IQuery<UsersQueryDto, UsersQueryParam>  query , IMapper mapper , LocalizeService localizeService)
  {
  
    _query = query;
    _mapper = mapper;
    _localizeService = localizeService;
  
  }
  public async Task<Result<QueryUserResponse>> Execute(QueryUserRequest requestDTO)
  {
     var userQueryResult =   _query.Execute(new UsersQueryParam { SearchText = requestDTO.SearchText , Limit = requestDTO.Limit , Start = requestDTO.Start}).ToList();
     return await Task.FromResult( Result.Success(new QueryUserResponse { UserQueryResult = userQueryResult }));
  }
}

