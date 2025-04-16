using FinanceControlAPI.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceControlAPI.Infrastructure.Migrations;
public static class DataBaseMigration
{
  public async static Task MigrateDataBase(IServiceProvider provider)
  {
    var dbContext = provider.GetRequiredService<FinanceDbContext>();

    await dbContext.Database.MigrateAsync();
  }
}
