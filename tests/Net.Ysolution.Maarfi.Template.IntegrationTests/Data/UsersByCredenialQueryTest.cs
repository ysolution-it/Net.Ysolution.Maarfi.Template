using Net.Ysolution.Maarfi.Template.Core.Domains.ProjectAggregate;
using Net.Ysolution.Maarfi.Template.Core.Dto.Queries;
using Net.Ysolution.Maarfi.Template.Infrastructure.Data.Queries;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;
using Net.Ysolution.Maarfi.Shared.Models.Dto;
using Xunit;

namespace Net.Ysolution.Maarfi.Template.IntegrationTests.Data;

public class UsersByCredenialQueryTest : BaseEfRepoTestFixture
{
  [Fact]
  public void Excute()
  {
    


    IQuery<UserDto, UserCredentialParam> query = new UsersByCredenialQuery(_readDbContext);
    query.Execute(new UserCredentialParam { UserName = "sss", Password = "ddddd" });

  }
}
