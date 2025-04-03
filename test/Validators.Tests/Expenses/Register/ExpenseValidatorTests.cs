using CommonTestUtilities.Requests;
using FinanceControlAPI.Application.UseCases.Expenses;
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
}
