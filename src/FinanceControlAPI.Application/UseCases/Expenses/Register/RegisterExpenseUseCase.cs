using AutoMapper;
using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses;
using FinanceControlAPI.Domain.Entities;
using FinanceControlAPI.Domain.Repositories;
using FinanceControlAPI.Exception.ExceptionBase;

namespace FinanceControlAPI.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
  private readonly IExpensesWriteRepository _repository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public RegisterExpenseUseCase(IExpensesWriteRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
  {
    _repository = repository;
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<RegisterExpenseResponse> Execute(RegisterExpenseRequest request)
  {
    Validate(request);

    var entity = _mapper.Map<Expense>(request);

    await _repository.Add(entity);

    await _unitOfWork.Commit();

    return _mapper.Map<RegisterExpenseResponse>(entity);
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
