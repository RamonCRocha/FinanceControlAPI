using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses.Users;

namespace FinanceControlAPI.Application.UseCases.Login;
public interface IDoLoginUseCase
{
  Task<RegisterUserResponse> Execute(LoginRequest request);
}
