using FinanceControlAPI.Communication.Responses.Expenses;

namespace FinanceControlAPI.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpensesUseCase
{
  Task<ExpensesResponse> Execute();
}
