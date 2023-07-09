namespace Net.Ysolution.Maarfi.Template.Core.Dto;

public class UpdateUserResponse
{
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Username { get; set; }

  public string Email { get; set; }
  public List<UpdateUserRoleResponse> UserRoles { get; set; }

  public Guid TenantId { get; set; }
}
