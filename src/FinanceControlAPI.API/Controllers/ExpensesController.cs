﻿using FinanceControlAPI.Application.UseCases.Expenses.Delete;
using FinanceControlAPI.Application.UseCases.Expenses.GetAll;
using FinanceControlAPI.Application.UseCases.Expenses.GetById;
using FinanceControlAPI.Application.UseCases.Expenses.Register;
using FinanceControlAPI.Application.UseCases.Expenses.Update;
using FinanceControlAPI.Communication.Requests;
using FinanceControlAPI.Communication.Responses;
using FinanceControlAPI.Communication.Responses.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControlAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ExpensesController : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(typeof(RegisterExpenseResponse), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> Register([FromServices] IRegisterExpenseUseCase useCase,
                                          [FromBody] RegisterExpenseRequest request)
  {
    var response = await useCase.Execute(request);

    return Created(string.Empty, response);
  }

  [HttpGet]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase)
  {
    var response = await useCase.Execute();

    if (response.Expenses.Count != 0)
      return Ok(response);

    return NoContent();
  }

  [HttpGet]
  [Route("{id}")]
  [ProducesResponseType(typeof(ExpenseResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetById([FromServices] IGetExpenseByIdUseCase useCase,
                                           [FromRoute] long id)
  {
    var response = await useCase.Execute(id);

    return Ok(response);
  }

  [HttpDelete]
  [Route("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Delete([FromServices] IDeleteExpenseUseCase useCase,
                                          [FromRoute] long id)
  {
    await useCase.Execute(id);

    return NoContent();
  }


  [HttpPut]
  [Route("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
  public async Task<IActionResult> Update([FromServices] IUpdateExpenseUseCase useCase,
                                          [FromRoute] long id,
                                          [FromBody] RegisterExpenseRequest request)
  {
    await useCase.Execute(id, request);

    return NoContent();
  }

}
