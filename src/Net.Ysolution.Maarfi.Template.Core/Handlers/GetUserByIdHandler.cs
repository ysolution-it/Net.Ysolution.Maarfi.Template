using AutoMapper;
using MediatR;
using Net.Ysolution.Maarfi.Template.Core.Interfaces;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Shared.Core.Commands;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;

namespace Net.Ysolution.Maarfi.Template.Core.Handlers;
public class GetUserByIdHandler : IRequestHandler<GetUserByIdCommand , UserDto>
{
  private readonly IQuery<UserDto, UserByIdParam> _userQuery;
  public readonly IMapper _mapper;
  public GetUserByIdHandler (IQuery<UserDto, UserByIdParam> userQuery , IMapper mapper)
  {
    _userQuery = userQuery;
    _mapper = mapper;
  }

  public async Task<UserDto> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    
  {
    var data = _userQuery.Execute(new UserByIdParam  { Id = request.UserId });
    return await _mapper.Map<Task<UserDto>>(data);
  }
}
