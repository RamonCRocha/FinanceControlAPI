using CommonTestUtilities.Requests;
using FinanceControlAPI.Application.UseCases.Expenses;
using FinanceControlAPI.Communication.Enums;
using FinanceControlAPI.Exception;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;
public class ExpenseValidatorTests
{
  [Fact]
  public void Success()
  {
    var validator = new ExpenseValidator();

    var request = RegisterExpenseRequestBuilder.Build();

    var result = validator.Validate(request);

    result.IsValid.Should().BeTrue();
  }

  [Theory]
  [InlineData("")]
  [InlineData("  ")]
  [InlineData(null)]
  public void ErrorTitleEmpty(string title)
  {
    var validator = new ExpenseValidator();
    var request = RegisterExpenseRequestBuilder.Build();
    request.Title = title;

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
  }

  [Fact]
  public void ErrorDateFuture()
  {
    var validator = new ExpenseValidator();
    var request = RegisterExpenseRequestBuilder.Build();
    request.Date = DateTime.UtcNow.AddDays(1);

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE));
  }

  [Fact]
  public void ErrorPaymentTypeInvalid()
  {
    var validator = new ExpenseValidator();
    var request = RegisterExpenseRequestBuilder.Build();
    request.PaymentType = (PaymentType)70;

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
  }

  [Theory]
  [InlineData(0)]
  [InlineData(-1)]
  public void ErrorAmountInvalid(decimal amount)
  {
    var validator = new ExpenseValidator();
    var request = RegisterExpenseRequestBuilder.Build();
    request.Amount = amount;

    var result = validator.Validate(request);

    result.IsValid.Should().BeFalse();
    result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
  }
}
