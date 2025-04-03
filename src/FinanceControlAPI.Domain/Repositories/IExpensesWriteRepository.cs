using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Domain.Repositories;
public interface IExpensesWriteRepository
{
  Task Add(Expense expense);
  Task<bool> Delete(long id);
}
