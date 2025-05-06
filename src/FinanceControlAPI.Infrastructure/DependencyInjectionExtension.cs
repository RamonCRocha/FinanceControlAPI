using FinanceControlAPI.Domain.Repositories;
using FinanceControlAPI.Domain.Repositories.Expenses;
using FinanceControlAPI.Domain.Repositories.Users;
using FinanceControlAPI.Domain.Secutiry.Cryptography;
using FinanceControlAPI.Infrastructure.DataAccess;
using FinanceControlAPI.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceControlAPI.Infrastructure;
public static class DependencyInjectionExtension
{
  public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    AddDbContext(services, configuration);
    AddRepositories(services);
    AddSecurityServices(services);
  }

  private static void AddRepositories(IServiceCollection services)
  {
    //UnitOfWork
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    //Expenses
    services.AddScoped<IExpensesReadRepository, ExpensesRepository>();
    services.AddScoped<IExpensesWriteRepository, ExpensesRepository>();
    services.AddScoped<IExpensesUpdateRepository, ExpensesRepository>();

    //Users
    services.AddScoped<IUsersReadRepository, UsersRepository>();
    services.AddScoped<IUsersWriteRepository, UsersRepository>();
  }

  private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Connection");

    services.AddDbContext<FinanceDbContext>(config => config.UseSqlServer(connectionString));
  }

  private static void AddSecurityServices(IServiceCollection services)
  {
    services.AddScoped<IPasswordEncrypter, Security.Cryptography.BCrypt>();
  }
}
