using FinanceControlAPI.Communication.Responses;

namespace FinanceControlAPI.Application.UseCases.Expenses.GetById;
public interface IGetExpenseByIdUseCase
{
  Task<ExpenseResponse> Execute(long id);
}
