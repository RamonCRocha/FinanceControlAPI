using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Domain.Repositories.Users;
public interface IUsersWriteRepository
{
  Task Add(User user);
}
