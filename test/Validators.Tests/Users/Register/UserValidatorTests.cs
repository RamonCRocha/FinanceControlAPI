using CommonTestUtilities.Requests;
using FinanceControlAPI.Application.UseCases.Users.Register;
using FinanceControlAPI.Exception;
using FluentAssertions;

namespace Validators.Tests.Users.Register;
public class UserValidatorTests
{
  [Fact]
  public void Success()
  {
    var validator = new RegisterUserValidator();
    var request = RegisterUserRequestBuilder.Build();

    var result = validator.Validate(request);

    result.IsValid.Should().BeTrue();
  }

  [Theory]
  [InlineData("  ")]
  [InlineData("")]
  [InlineData(null)]
  public void ErrorNameEmpty(string name)
  {
    var validator = new RegisterUserValidator();
    var request = RegisterUserRequestBuilder.Build();
    request.Name = name;

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));
  }

  [Theory]
  [InlineData("  ")]
  [InlineData("")]
  [InlineData(null)]
  public void ErrorEmailEmpty(string email)
  {
    var validator = new RegisterUserValidator();
    var request = RegisterUserRequestBuilder.Build();
    request.Email = email;

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY));
  }

  [Fact]
  public void ErrorEmailInvalid()
  {
    var validator = new RegisterUserValidator();
    var request = RegisterUserRequestBuilder.Build();
    request.Email = "ramon.com";

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_INVALID));
  }

  [Fact]
  public void ErrorPasswordEmpty()
  {
    var validator = new RegisterUserValidator();
    var request = RegisterUserRequestBuilder.Build();
    request.Password = string.Empty;

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.INVALID_PASSWORD));
  }
}
