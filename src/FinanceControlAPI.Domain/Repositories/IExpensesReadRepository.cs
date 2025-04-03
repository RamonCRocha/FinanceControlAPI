using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Domain.Repositories;
public interface IExpensesReadRepository
{
  Task<List<Expense>> GetAll();
  Task<Expense?> GetById(long id);
}
