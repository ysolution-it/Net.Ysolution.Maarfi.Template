
using AutoMapper;
using MediatR;
using Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.ModuleAggregate.Specifications;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Shared.Core.Commands;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Core.Handlers;
public class GetModulesByIdsHandler : IRequestHandler<GetModulesByIdsCommand, List<ModuleDto>>
{
  private readonly IRepository<Module> _repository;
  private readonly IMapper _mapper;


  public GetModulesByIdsHandler(IRepository<Module> repository , IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  
  }

  public async Task<List<ModuleDto>> Handle(GetModulesByIdsCommand request, CancellationToken cancellationToken)
  {
    var data = await _repository.ListAsync(new ModulesByIdsSpec(request.ModuleIds));
    
    return _mapper.Map<IEnumerable<ModuleDto>>(data).ToList();
   
  }
}
