using System.Net;

namespace FinanceControlAPI.Exception.ExceptionBase;
public class NotFoundException : FinanceException
{
  public NotFoundException(string message) : base(message) { }

  public override int StatusCode => (int)HttpStatusCode.NotFound;

  public override List<string> GetErrors()
  {
    return [Message];
  }
}
