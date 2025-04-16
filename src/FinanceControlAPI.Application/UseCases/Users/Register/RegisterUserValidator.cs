using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Exception;
using FluentValidation;

namespace FinanceControlAPI.Application.UseCases.Users.Register;
public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
  public RegisterUserValidator()
  {
    RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
    RuleFor(user => user.Email)
      .NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY)
      .EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_INVALID);

    RuleFor(user => user.Password).SetValidator(new PasswordValidator<RegisterUserRequest>());
  }
}
