namespace Net.Ysolution.Maarfi.Template.Core.Dto;

public class UpdateUserRequest
{
  public Guid Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Username { get; set; }

  public string Email { get; set; }
  public List<UpdateUserRoleRequest> Roles { get; set; }

  public Guid TenantId { get; set; }
}
