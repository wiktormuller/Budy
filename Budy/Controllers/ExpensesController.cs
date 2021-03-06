using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using Budy.Application.Expenses.Filters;
using Budy.Application.Expenses.Queries;
using Budy.Application.Expenses.Requests;
using Budy.Application.Expenses.Responses;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenseResponse>>> GetAll([FromQuery] GetAllExpensesFilter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var query = new GetAllExpensesQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<ExpenseResponse>> GetById(int id)
        {
            try
            {
                var query = new GetExpenseByIdQuery(id);
                return Ok(await _mediator.Send(query));
            }
            catch (ExpenseNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateExpenseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var command = new CreateExpenseCommand
                {
                    Name = request.Name,
                    Amount = request.Amount,
                    CategoryId = request.CategoryId,
                    OccuredAt = request.OccuredAt
                };

                var expenseId = await _mediator.Send(command);
                
                return CreatedAtAction(nameof(Create), new {Id = expenseId});
            }
            catch (CategoryNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateExpenseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = new EditExpenseCommand
                {
                    Id = id,
                    Amount = request.Amount,
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    OccuredAt = request.OccuredAt
                };

                await _mediator.Send(command);

                return NoContent();
            }
            catch (ExpenseNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (CategoryNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteExpenseCommand(id);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (ExpenseNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}