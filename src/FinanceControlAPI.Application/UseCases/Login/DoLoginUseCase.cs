using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses.Users;
using FinanceControlAPI.Domain.Repositories.Users;
using FinanceControlAPI.Domain.Secutiry.Cryptography;
using FinanceControlAPI.Domain.Secutiry.Tokens;
using FinanceControlAPI.Exception.ExceptionBase;

namespace FinanceControlAPI.Application.UseCases.Login;
public class DoLoginUseCase
{
  private readonly IUsersReadRepository _userReadRepository;
  private readonly IPasswordEncrypter _passwordEncrypt;
  private readonly IAccessTokenGenerator _accessTokenGenerator;

  public DoLoginUseCase(IUsersReadRepository userReadRepository, IPasswordEncrypter passwordEncrypt, IAccessTokenGenerator accessTokenGenerator)
  {
    _userReadRepository = userReadRepository;
    _passwordEncrypt = passwordEncrypt;
    _accessTokenGenerator = accessTokenGenerator;
  }

  public async Task<RegisterUserResponse> Execute(LoginRequest request)
  {
    var user = await _userReadRepository.GetUserByEmail(request.Email);

    if (user is null)
      throw new InvalidLoginException();

    var passwordMatch = _passwordEncrypt.Verify(request.Password, user.Password);

    if (!passwordMatch)
      throw new InvalidLoginException();

    return new RegisterUserResponse
    {
      Name = user.Name,
      Token = _accessTokenGenerator.Generate(user)
    };
  }
}
