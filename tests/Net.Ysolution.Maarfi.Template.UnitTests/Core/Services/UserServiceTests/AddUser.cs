
using Moq;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
using Net.Ysolution.Maarfi.Template.Core.Services;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Xunit;

namespace Net.Ysolution.Maarfi.Template.UnitTests.Core.Services.UserServiceTests;
public class AddUser
{

  private readonly Guid _userId = Guid.NewGuid();
  private readonly Mock<IRepository<User>> _mockBasketRepo = new();

  [Fact]
  public async Task InvokesBasketRepositoryGetBySpecAsyncOnce()
  {
    //var user = new User();
    //var userService = new UserService(_mockBasketRepo.Object);
    //await userService.UpdateUser(user);
    //_mockBasketRepo.Verify(x => x.AddAsync(user , default), Times.Once);
  }

  

}
