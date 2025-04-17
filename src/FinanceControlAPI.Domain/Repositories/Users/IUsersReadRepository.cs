namespace FinanceControlAPI.Domain.Repositories.Users;
public interface IUsersReadRepository
{
  Task<bool> ExistActiveUserWithEmail(string email);
}
