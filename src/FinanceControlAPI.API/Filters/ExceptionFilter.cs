using FinanceControlAPI.Communication.Responses;
using FinanceControlAPI.Exception;
using FinanceControlAPI.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinanceControlAPI.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    if (context.Exception is FinanceException)
      HandleProjectException(context);
    else
      ThrowUnkowError(context);
  }


  private void HandleProjectException(ExceptionContext context)
  {
    var cashFlowException = context.Exception as FinanceException;
    var errorResponse = new ErrorResponse(cashFlowException!.GetErrors());

    context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
    context.Result = new ObjectResult(errorResponse);

  }

  private void ThrowUnkowError(ExceptionContext context)
  {
    var errorResponse = new ErrorResponse(ResourceErrorMessages.UNKNOWN_ERROR);

    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
    context.Result = new ObjectResult(errorResponse);
  }
}
