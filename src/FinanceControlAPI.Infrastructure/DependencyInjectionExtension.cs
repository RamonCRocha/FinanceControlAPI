using FinanceControlAPI.Domain.Repositories;
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
  }

  private static void AddRepositories(IServiceCollection services)
  {
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped<IExpensesReadRepository, ExpensesRepository>();
    services.AddScoped<IExpensesWriteRepository, ExpensesRepository>();
    services.AddScoped<IExpensesUpdateRepository, ExpensesRepository>();
  }

  private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Connection");

    services.AddDbContext<FinanceDbContext>(config => config.UseSqlServer(connectionString));
  }
}
