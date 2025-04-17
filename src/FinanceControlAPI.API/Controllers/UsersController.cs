using FinanceControlAPI.Application.UseCases.Users.Register;
using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses;
using FinanceControlAPI.Communication.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControlAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, [FromBody] RegisterUserRequest request)
  {
    var response = await useCase.Execute(request);

    return Created(string.Empty, response);
  }
}
