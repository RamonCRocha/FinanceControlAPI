using FinanceControlAPI.Application.UseCases.Expenses;
using FinanceControlAPI.Communication.Requests;

namespace Validators.Tests.Expenses.Register;
public class ExpenseValidatorTests
{
  [Fact]
  public void Success()
  {
    var validator = new ExpenseValidator();

    var request = new RegisterExpenseRequest
    {
      Amount = 100,
      Date = DateTime.Now.AddDays(-1),
      Title = "Test",
      PaymentType = FinanceControlAPI.Communication.Enums.PaymentType.DebitCard
    };

    var result = validator.Validate(request);

    Assert.True(result.IsValid);
  }
}
