using FinanceControlAPI.Domain.Secutiry.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace FinanceControlAPI.Infrastructure.Security.Cryptography;
internal class BCrypt : IPasswordEncrypter
{
  public string Encrypt(string password)
  {
    string passwordHash = BC.HashPassword(password);

    return passwordHash;
  }

  public bool Verify(string password, string passwordHash)
  {
    return BC.Verify(password, passwordHash);
  }
}
