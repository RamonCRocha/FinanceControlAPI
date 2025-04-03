using AutoMapper;
using FinanceControlAPI.Communication.Responses;
using FinanceControlAPI.Domain.Repositories;
using FinanceControlAPI.Exception;
using FinanceControlAPI.Exception.ExceptionBase;

namespace FinanceControlAPI.Application.UseCases.Expenses.GetById;
public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
  private readonly IExpensesReadRepository _repository;
  private readonly IMapper _mapper;

  public GetExpenseByIdUseCase(IExpensesReadRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  public async Task<ExpenseResponse> Execute(long id)
  {
    var result = await _repository.GetById(id);

    if (result is null)
      throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

    return _mapper.Map<ExpenseResponse>(result);
  }
}
