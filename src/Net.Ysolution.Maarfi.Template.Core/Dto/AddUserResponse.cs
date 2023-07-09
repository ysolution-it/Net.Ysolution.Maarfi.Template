namespace Net.Ysolution.Maarfi.Template.Core.Services.Dto.AddUser;

public class AddUserRequest
{

  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Username { get; set; }

  public string Email { get; set; }
  public string Password { get; set; }
  public List<AddUserRoleRequest> UserRoles { get; set; }

  public Guid TenantId { get; set; }


}


