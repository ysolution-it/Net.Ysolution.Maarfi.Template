using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Specifications;
using Net.Ysolution.Maarfi.Template.SharedKernel.Interfaces;

namespace Net.Ysolution.Maarfi.Template.Core.Domains.UserAggregate.Validations;
public class UpdateUserValidator : AbstractValidator<User>
{
  private readonly IRepository<User> _repository;

  public UpdateUserValidator(IRepository<User> repository)
  {
    RuleFor(user => user.FirstName).NotNull().MaximumLength(100).WithErrorCode("FirstNameNull");
    RuleFor(user => user.LastName).NotNull().MaximumLength(100).WithErrorCode("LastNameNull");
    RuleFor(user => user.Email).NotNull().EmailAddress().WithErrorCode("WrongEmail");
    RuleFor(user => user.Password).MinimumLength(6).MaximumLength(100).WithErrorCode("NotValidPassword").When(p=> p.Password != "");
    _repository = repository;
  }
 
}
