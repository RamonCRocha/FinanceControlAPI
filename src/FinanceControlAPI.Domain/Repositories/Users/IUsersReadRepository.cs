using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Domain.Repositories.Users;
public interface IUsersReadRepository
{
  Task<bool> ExistActiveUserWithEmail(string email);
  Task<User?> GetUserByEmail(string email);
}
