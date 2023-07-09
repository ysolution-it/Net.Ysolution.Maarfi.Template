
using System.Security.Cryptography;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Bases;
using Net.Ysolution.Maarfi.Shared.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate;
public  class User : BaseEntity<Guid> , IAggregateRoot , IEntityWithTenant
{


  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public string Username { get; private set; }

  public string Email { get; private set; }
  public string Password { get; private set; }
  public IEnumerable<UserRole> UserRoles => _userRoles.AsReadOnly();
  public Guid TenantId { get; set; }

  private List<UserRole> _userRoles = new List<UserRole>();
   User()
  {

  }
  public User(string firstName, string lastName, string username, string email, string password, Guid tenantId  ) 
  {
    FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName) , "FirstNameNull");  
    LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName), "LastNameNull");
    Username = Guard.Against.NullOrEmpty(username, nameof(username) , "UsernameNull") ;
    Email = Guard.Against.NullOrEmpty(email, nameof(email) , "UsernameNull") ;
    Password = HashPassword(Guard.Against.NullOrEmpty(password, nameof(password)));
    TenantId = tenantId;
  }


  public void AddUserRole(UserRole userRole)
  {
    _userRoles.Add(userRole);
  }

  private string HashPassword(string password)
  {


    byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

    Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

    // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: password,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA256,
        iterationCount: 100000,
        numBytesRequested: 256 / 8));
    return hashed;


  }
}
