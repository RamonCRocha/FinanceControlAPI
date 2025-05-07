using System.Net;

namespace FinanceControlAPI.Exception.ExceptionBase;
public class InvalidLoginException : FinanceException
{
  public InvalidLoginException() : base(ResourceErrorMessages.INVALID_EMAIL_OR_PASSWORD)
  {
  }

  public override int StatusCode => (int)HttpStatusCode.Unauthorized;

  public override List<string> GetErrors()
  {
    return [Message];
  }
}
