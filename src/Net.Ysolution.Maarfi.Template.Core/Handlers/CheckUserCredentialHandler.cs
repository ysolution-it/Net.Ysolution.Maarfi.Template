using AutoMapper;
using MediatR;
using Net.Ysolution.Maarfi.Template.Core.Interfaces;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Shared.Core.Commands;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Core.Handlers;
public class CheckUserCredentialHandler : IRequestHandler<CheckUserCredentialCommand, UserDto>
{
  public readonly IQuery<UserDto , UserCredentialParam> _userQuery;
  public readonly IMapper _mapper;
  public CheckUserCredentialHandler (IQuery<UserDto, UserCredentialParam> userQuery, IMapper mapper)
  {
    _userQuery = userQuery;
    _mapper = mapper;
  }

  public async Task<UserDto> Handle(CheckUserCredentialCommand request, CancellationToken cancellationToken)
  {
    UserCredentialParam userCredentialParam = new UserCredentialParam { UserName = request.UserName, Password = request.Password };
    var data =  _userQuery.Execute(userCredentialParam).ToList();
    return await Task.FromResult(data.First());
  }
}
