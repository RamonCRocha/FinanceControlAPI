﻿using Bogus;
using FinanceControlAPI.Communication.Enums;
using FinanceControlAPI.Communication.Requests;

namespace CommonTestUtilities.Requests;
public static class RegisterExpenseRequestBuilder
{
  public static RegisterExpenseRequest Build()
  {
    return new Faker<RegisterExpenseRequest>()
      .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
      .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
      .RuleFor(r => r.Date, faker => faker.Date.Past())
      .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
      .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
  }
}
