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
  }

  private static void AddUseCases(IServiceCollection services)
  {
  }
}
