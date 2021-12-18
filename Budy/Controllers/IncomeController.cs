using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Application.Income.Commands;
using Budy.Application.Income.Queries;
using Budy.Application.Income.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public IncomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<object>>> GetAll()
        {
            var query = new GetAllIncomeQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            try
            {
                var query = new GetIncomeByIdQuery(id);
                return Ok(await _mediator.Send(query));
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateIncomeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var command = new CreateIncomeCommand
                {
                    Name = request.Name,
                    Amount = request.Amount,
                    OccuredAt = request.OccuredAt,
                    CategoryId = request.CategoryId
                };
                var incomeId = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetById), new {Id = incomeId});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateIncomeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var command = new EditIncomeCommand
                {
                    Id = id,
                    Name = request.Name,
                    Amount = request.Amount,
                    OccuredAt = request.OccuredAt,
                    CategoryId = request.CategoryId
                };

                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception e)
            {
                //return NotFound(); @ TODO
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteIncomeCommand
                {
                    Id = id
                };
                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
    }
}