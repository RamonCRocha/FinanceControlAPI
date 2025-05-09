﻿using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses.Expenses;

namespace FinanceControlAPI.Application.UseCases.Expenses.Register;
public interface IRegisterExpenseUseCase
{
  Task<RegisterExpenseResponse> Execute(RegisterExpenseRequest request);
}
