﻿namespace FinanceControlAPI.Domain.Repositories;
public interface IUnitOfWork
{
  Task Commit();
}
