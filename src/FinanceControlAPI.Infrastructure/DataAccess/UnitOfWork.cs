using FinanceControlAPI.Domain.Repositories;

namespace FinanceControlAPI.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
  private readonly FinanceDbContext _dbContext;

  public UnitOfWork(FinanceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task Commit() => await _dbContext.SaveChangesAsync();
}
