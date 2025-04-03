using FinanceControlAPI.Communication.Requests;

namespace FinanceControlAPI.Application.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
  Task Execute(long id, RegisterExpenseRequest request);

}
