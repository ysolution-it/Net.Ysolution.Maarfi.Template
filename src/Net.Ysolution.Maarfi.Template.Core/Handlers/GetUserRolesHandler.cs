using AutoMapper;
using MediatR;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Template.Core.Interfaces;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Shared.Core.Commands;
using Net.Ysolution.Maarfi.Shared.Models.Dto;

namespace Net.Ysolution.Maarfi.Template.Core.Handlers;
public class GetUserRolesHandler : IRequestHandler<GetUserRolesCommand, List<UserRolesDto>>
{
  private readonly IQuery<UserRolesDto, UserRolesParam> _userQuery;
  public readonly IMapper _mapper;
  public GetUserRolesHandler(IQuery<UserRolesDto, UserRolesParam> userQuery, IMapper mapper)
  {
    _userQuery = userQuery;
    _mapper = mapper;
  }

  public async Task<List<UserRolesDto>> Handle(GetUserRolesCommand request, CancellationToken cancellationToken)
  {
    UserRolesParam userRolesParam = new UserRolesParam { Id = request.UserId };
    var data =  _userQuery.Execute(userRolesParam).ToList();
    //Flattren user object to UserRolesDto;
    return await Task.FromResult(data);
   
  }
}
