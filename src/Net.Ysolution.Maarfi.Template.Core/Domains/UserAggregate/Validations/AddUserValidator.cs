using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate;
using Net.Ysolution.Maarfi.Template.Core.Domains.RoleAggregate.Specifications;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Specifications;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Validations;
public class AddUserValidator : AbstractValidator<User>
{
  private readonly IRepository<User> _userRepository;
  private readonly IRepository<Role> _roleRepository;

  public AddUserValidator(IRepository<User> userRepository , IRepository<Role> roleRepository)
  {
    RuleFor(user => user.FirstName).NotNull().MaximumLength(100).WithErrorCode("FirstNameNull");
    RuleFor(user => user.LastName).NotNull().MaximumLength(100).WithErrorCode("LastNameNull");
    RuleFor(user => user.Email).NotNull().EmailAddress().WithErrorCode("WrongEmail");
    RuleFor(user => user.Password).MinimumLength(6).MaximumLength(100).WithErrorCode("NotValidPassword");
    RuleFor(user => user.Email).Must(EnsureEmailUniqe).WithErrorCode("UserAlreadyExist");
    RuleForEach(user => user.UserRoles).Must(EnsureRoleExist).WithErrorCode("RoleNotExist");
    _userRepository = userRepository;
    _roleRepository = roleRepository;
  }
  protected  bool EnsureEmailUniqe(User user , string email)
  {
    if (_userRepository.CountAsync(new CheckUserUniqSpec(user)).Result > 0)
      return false;
    else return true;
  }


  protected bool EnsureRoleExist(UserRole userRole)
  {
    if (_roleRepository.CountAsync(new CheckRoleExistSpec(userRole.RoleId)).Result > 0)
      return true;
    else return false;
  }


  

}
