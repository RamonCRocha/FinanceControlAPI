using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Domain.Repositories.Expenses;
public interface IExpensesWriteRepository
{
  Task Add(Expense expense);
  Task<bool> Delete(long id);
}
