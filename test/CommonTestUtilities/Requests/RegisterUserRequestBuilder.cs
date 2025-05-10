using Bogus;
using FinanceControlAPI.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RegisterUserRequestBuilder
{
  public static RegisterUserRequest Build()
  {
    return new Faker<RegisterUserRequest>()
      .RuleFor(user => user.Name, faker => faker.Person.FirstName)
      .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
      .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa1"));
  }
}
