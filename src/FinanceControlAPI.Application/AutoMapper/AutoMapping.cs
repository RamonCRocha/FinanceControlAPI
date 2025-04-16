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
    //Expenses
    CreateMap<RegisterExpenseRequest, Expense>();

    //Users
    CreateMap<RegisterUserRequest, User>()
      .ForMember(user => user.Password, config => config.Ignore());
  }

  private void EntityToResponse()
  {
    //Expenses
    CreateMap<Expense, RegisterExpenseResponse>();
    CreateMap<Expense, ShortExpenseResponse>();
    CreateMap<Expense, ExpenseResponse>();
  }
}
