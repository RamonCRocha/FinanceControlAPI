﻿using FinanceControlAPI.Communication.Enums;

namespace FinanceControlAPI.Communication.Responses.Expenses;
public class ExpenseResponse
{
  public long Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string? Description { get; set; }
  public DateTime Date { get; set; }
  public decimal Amount { get; set; }
  public PaymentType PaymentType { get; set; }
}
