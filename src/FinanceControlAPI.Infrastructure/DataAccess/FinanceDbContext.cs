using FinanceControlAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceControlAPI.Infrastructure.DataAccess;
public class FinanceDbContext : DbContext
{
  public FinanceDbContext(DbContextOptions options) : base(options) { }

  public DbSet<Expense> Expenses { get; set; }
}
