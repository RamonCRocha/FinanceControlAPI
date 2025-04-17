using FinanceControlAPI.Domain.Secutiry.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace FinanceControlAPI.Infrastructure.Security;
internal class BCrypt : IPasswordEncrypter
{
  public string Encrypt(string password)
  {
    string passwordHash = BC.HashPassword(password);

    return passwordHash;
  }
}
