using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Domain.Secutiry.Tokens;
public interface IAccessTokenGenerator
{
  string Generate(User user);
}
