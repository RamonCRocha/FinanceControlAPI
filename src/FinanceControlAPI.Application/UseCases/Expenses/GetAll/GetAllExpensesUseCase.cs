using AutoMapper;
using FinanceControlAPI.Communication.Responses.Expenses;
using FinanceControlAPI.Domain.Repositories.Expenses;

namespace FinanceControlAPI.Application.UseCases.Expenses.GetAll;
public class GetAllExpensesUseCase : IGetAllExpensesUseCase
{
  private readonly IExpensesReadRepository _repository;
  private readonly IMapper _mapper;

  public GetAllExpensesUseCase(IExpensesReadRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }
  public async Task<ExpensesResponse> Execute()
  {
    var result = await _repository.GetAll();

    return new ExpensesResponse
    {
      Expenses = _mapper.Map<List<ShortExpenseResponse>>(result)
    };
  }
}
