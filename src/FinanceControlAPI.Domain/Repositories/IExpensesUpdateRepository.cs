using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Domain.Repositories;
public interface IExpensesUpdateRepository
{
  Task<Expense?> GetById(long id);
  void Update(Expense expense);
}
