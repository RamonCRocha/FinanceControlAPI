using AutoMapper;
using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses.Expenses;
using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Application.AutoMapper;
public class AutoMapping : Profile
{
  public AutoMapping()
  {
    RequestToEntity();
    EntityToResponse();
  }

  private void RequestToEntity()
  {
    CreateMap<RegisterExpenseRequest, Expense>();
  }

  private void EntityToResponse()
  {
    CreateMap<Expense, RegisterExpenseResponse>();
    CreateMap<Expense, ShortExpenseResponse>();
    CreateMap<Expense, ExpenseResponse>();
  }
}
