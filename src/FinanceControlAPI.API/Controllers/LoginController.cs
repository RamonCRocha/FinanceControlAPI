using FinanceControlAPI.Application.UseCases.Login;
using FinanceControlAPI.Communication.Responses.Users;
using FinanceControlAPI.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceControlAPI.Communication.Requests;

namespace FinanceControlAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
  public async Task<IActionResult> Login([FromServices] IDoLoginUseCase useCase, [FromBody] LoginRequest request)
  {
    var response = await useCase.Execute(request);

    return Ok(response);
  }
}
