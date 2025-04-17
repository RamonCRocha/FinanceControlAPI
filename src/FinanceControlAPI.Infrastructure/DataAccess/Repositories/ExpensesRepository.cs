using FinanceControlAPI.Domain.Entities;
using FinanceControlAPI.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace FinanceControlAPI.Infrastructure.DataAccess.Repositories;
internal class ExpensesRepository : IExpensesReadRepository, IExpensesWriteRepository, IExpensesUpdateRepository
{
  private readonly FinanceDbContext _dbContext;

  public ExpensesRepository(FinanceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task Add(Expense expense)
  {
    await _dbContext.Expenses.AddAsync(expense);
  }

  public async Task<bool> Delete(long id)
  {
    var result = await _dbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);
    if (result is null)
      return false;

    _dbContext.Expenses.Remove(result);

    return true;
  }

  public async Task<List<Expense>> GetAll()
  {
    return await _dbContext.Expenses.AsNoTracking().ToListAsync();
  }

  async Task<Expense?> IExpensesReadRepository.GetById(long id)
  {
    return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
  }

  async Task<Expense?> IExpensesUpdateRepository.GetById(long id)
  {
    return await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
  }

  public void Update(Expense expense)
  {
    _dbContext.Expenses.Update(expense);
  }
}
