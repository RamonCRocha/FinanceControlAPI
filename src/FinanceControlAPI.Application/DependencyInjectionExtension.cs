using FinanceControlAPI.Application.AutoMapper;
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
  }
}
