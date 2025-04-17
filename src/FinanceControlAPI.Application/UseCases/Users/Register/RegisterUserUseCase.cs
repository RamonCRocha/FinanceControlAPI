using AutoMapper;
using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses.Users;
using FinanceControlAPI.Domain.Repositories;
using FinanceControlAPI.Domain.Repositories.Users;
using FinanceControlAPI.Domain.Secutiry.Cryptography;
using FinanceControlAPI.Exception.ExceptionBase;
using FinanceControlAPI.Exception;
using FluentValidation.Results;
using FinanceControlAPI.Domain.Entities;

namespace FinanceControlAPI.Application.UseCases.Users.Register;
public class RegisterUserUseCase : IRegisterUserUseCase
{
  private readonly IMapper _mapper;
  private readonly IPasswordEncrypter _passwordEncrypter;
  private readonly IUsersReadRepository _readRepository;
  private readonly IUsersWriteRepository _writeRepository;
  private readonly IUnitOfWork _unitOfWork;

  public RegisterUserUseCase(IMapper mapper, IPasswordEncrypter passwordEncrypter, IUsersReadRepository readRepository, IUsersWriteRepository writeRepository, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _passwordEncrypter = passwordEncrypter;
    _readRepository = readRepository;
    _writeRepository = writeRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<RegisterUserResponse> Execute(RegisterUserRequest request)
  {
    await Validate(request);

    var user = _mapper.Map<User>(request);
    user.Password = _passwordEncrypter.Encrypt(request.Password);
    user.UserIdentifier = Guid.NewGuid();

    await _writeRepository.Add(user);

    await _unitOfWork.Commit();

    return new RegisterUserResponse
    {
      Name = user.Name,
    };
  }

  private async Task Validate(RegisterUserRequest request)
  {
    var result = new RegisterUserValidator().Validate(request);

    var emailExist = await _readRepository.ExistActiveUserWithEmail(request.Email);

    if (emailExist)
      result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));

    if (!result.IsValid)
    {
      var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

      throw new ErrorOnValidationException(errorMessages);
    }
  }
}
