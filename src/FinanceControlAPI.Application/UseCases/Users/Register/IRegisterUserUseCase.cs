using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses.Users;

namespace FinanceControlAPI.Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
  Task<RegisterUserResponse> Execute(RegisterUserRequest request);
}
