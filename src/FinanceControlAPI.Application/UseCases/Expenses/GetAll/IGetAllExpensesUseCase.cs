using FinanceControlAPI.Communication.Responses;

namespace FinanceControlAPI.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpensesUseCase
{
  Task<ExpensesResponse> Execute();
}
