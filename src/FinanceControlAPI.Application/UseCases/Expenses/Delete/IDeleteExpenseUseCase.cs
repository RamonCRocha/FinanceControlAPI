namespace FinanceControlAPI.Application.UseCases.Expenses.Delete;
public interface IDeleteExpenseUseCase
{
  Task Execute(long id);
}
