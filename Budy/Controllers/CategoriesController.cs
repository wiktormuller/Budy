using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using Budy.Application.Categories.Queries;
using Budy.Application.Categories.Requests;
using Budy.Application.Categories.Responses;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<CategoryResponse>>> GetAll()
        {
            var query = new GetAllCategoriesQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<CategoryResponse>> GetById(int id)
        {
            try
            {
                var query = new GetCategoryByIdQuery(id);
                return Ok(await _mediator.Send(query));
            }
            catch (CategoryNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var command = new CreateCategoryCommand
            {
                Name = request.Name
            };

            var categoryId = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), new {Id = categoryId});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = new EditCategoryCommand
                {
                    Name = request.Name
                };

                await _mediator.Send(command);
                
                return NoContent();
            }
            catch (CategoryNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteCategoryCommand(id);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (CategoryNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}