using FinanceControlAPI.Application.UseCases.Users;
using FinanceControlAPI.Communication.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validators.Tests.Users;
public class PasswordValidatorTests
{
  [Theory]
  [InlineData("  ")]
  [InlineData("")]
  [InlineData(null)]
  [InlineData("a")]
  [InlineData("aa")]
  [InlineData("aaa")]
  [InlineData("aaaa")]
  [InlineData("aaaaa")]
  [InlineData("aaaaaa")]
  [InlineData("aaaaaaa")]
  [InlineData("aaaaaaaa")]
  [InlineData("AAAAAAAA")]
  [InlineData("Aaaaaaaa")]
  [InlineData("Aaaaaaa1")]
  public void Error_Password_Invalid(string password)
  {
    var validator = new PasswordValidator<RegisterUserRequest>();

    var result = validator
      .IsValid(new ValidationContext<RegisterUserRequest>(new RegisterUserRequest()), password);

    result.Should().BeFalse();
  }
}
