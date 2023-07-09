using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Template.Core.Services;
using Net.Ysolution.Maarfi.Template.Core.Services.Dto.AddUser;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Template.Core;
using Xunit;
using Net.Ysolution.Maarfi.Template.Core.Resources;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;

namespace Net.Ysolution.Maarfi.Template.UnitTests.Core.Services;
public class AddUserUserStoryTest
{
  private readonly Guid _userId = Guid.NewGuid();
  private readonly Mock<IRepository<User>> _mockUserRepo = new();
  private readonly Mock<IRepository<Role>> _mockRoleRepo = new();
  private static IMapper _mapper;
  private static LocalizeService  _localizeService;
  public AddUserUserStoryTest()
  {
    if (_mapper == null)
    {
      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new AutoMapperProfile());
      });
      IMapper mapper = mappingConfig.CreateMapper();
      _mapper = mapper;
    }
  }
  [Fact]
  public async Task InvokesBasketRepositoryGetBySpecAsyncOnce()
  {
      var userRequest = new AddUserRequest { FirstName = "Khaled", LastName = "Fathy", Username = "k_fathy@yahoo.com", Email = "k_fathy@yahoo.com", Password = "a123", TenantId = Guid.Parse("32e6cfdf-6955-4207-9e04-053111b8ec34") };
     var userService = new AddUserUserStroy(_mockUserRepo.Object , _mockRoleRepo.Object , _mapper , _localizeService);
      await userService.Execute(userRequest);
   
     // _mockUserRepo.(x => x.GetByIdAsync(userId , new CancellationToken()), Times.Once);

    //Assert.Equal(_mockUserRepo.Object.GetByIdAsync(userId).Result.ToString(), userId.ToString());

  }

}
