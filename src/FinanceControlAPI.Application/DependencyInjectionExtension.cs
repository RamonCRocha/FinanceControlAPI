using FinanceControlAPI.Application.AutoMapper;
using FinanceControlAPI.Application.UseCases.Expenses.Delete;
using FinanceControlAPI.Application.UseCases.Expenses.GetAll;
using FinanceControlAPI.Application.UseCases.Expenses.GetById;
using FinanceControlAPI.Application.UseCases.Expenses.Register;
using FinanceControlAPI.Application.UseCases.Expenses.Update;
using FinanceControlAPI.Application.UseCases.Login;
using FinanceControlAPI.Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceControlAPI.Application;
public static class DependencyInjectionExtension
{
  public static void AddApplication(this IServiceCollection services)
  {
    AddAutoMapper(services);
    AddUseCases(services);
  }

  private static void AddAutoMapper(IServiceCollection services)
  {
    services.AddAutoMapper(typeof(AutoMapping));
  }

  private static void AddUseCases(IServiceCollection services)
  {
    //Expenses
    services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
    services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
    services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
    services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
    services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();

    //Users
    services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();

    //Login
    services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
  }
}
