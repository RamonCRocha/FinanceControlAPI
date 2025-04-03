﻿namespace FinanceControlAPI.Communication.Responses;
public class ErrorResponse
{
  public List<string> ErrorMessages { get; set; }

  public ErrorResponse(string errorMessage)
  {
    ErrorMessages = [errorMessage];
  }

  public ErrorResponse(List<string> errorMessages)
  {
    ErrorMessages = errorMessages;
  }
}
