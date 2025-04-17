namespace FinanceControlAPI.Domain.Secutiry.Cryptography;
public interface IPasswordEncrypter
{
  string Encrypt(string password);
}
