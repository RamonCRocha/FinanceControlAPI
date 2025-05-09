﻿using AutoMapper;
using FinanceControlAPI.Domain.Repositories;
using FinanceControlAPI.Exception.ExceptionBase;
using FinanceControlAPI.Exception;
using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Domain.Repositories.Expenses;

namespace FinanceControlAPI.Application.UseCases.Expenses.Update;
public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
  private readonly IMapper _mapper;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IExpensesUpdateRepository _repository;

  public UpdateExpenseUseCase(IMapper mapper, IUnitOfWork unitOfWork, IExpensesUpdateRepository repository)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
    _repository = repository;
  }

  public async Task Execute(long id, RegisterExpenseRequest request)
  {
    Validate(request);

    var expense = await _repository.GetById(id);

    if (expense is null)
      throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

    _mapper.Map(request, expense);

    _repository.Update(expense);

    await _unitOfWork.Commit();
  }

  private void Validate(RegisterExpenseRequest request)
  {
    var validator = new ExpenseValidator();

    var result = validator.Validate(request);

    if (!result.IsValid)
    {
      var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

      throw new ErrorOnValidationException(errorMessages);
    }
  }
}
