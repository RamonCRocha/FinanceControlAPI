using FinanceControlAPI.Domain.Entities;
using FinanceControlAPI.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace FinanceControlAPI.Infrastructure.DataAccess.Repositories;
internal class UsersRepository : IUsersReadRepository, IUsersWriteRepository
{
  private readonly FinanceDbContext _dbContext;

  public UsersRepository(FinanceDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task Add(User user)
  {
    await _dbContext.Users.AddAsync(user);
  }

  public async Task<bool> ExistActiveUserWithEmail(string email)
  {
    return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
  }

  public async Task<User?> GetUserByEmail(string email)
  {
    return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Email == email);
  }
}
