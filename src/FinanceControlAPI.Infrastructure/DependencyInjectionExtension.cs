using FinanceControlAPI.Infrastructure.DataAccess;
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
  }

  private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Connection");

    services.AddDbContext<FinanceDbContext>(config => config.UseSqlServer(connectionString));
  }
}
