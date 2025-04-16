using FinanceControlAPI.Communication.Responses.Expenses;

namespace FinanceControlAPI.Application.UseCases.Expenses.GetById;
public interface IGetExpenseByIdUseCase
{
  Task<ExpenseResponse> Execute(long id);
}
