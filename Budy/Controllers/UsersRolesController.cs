using System;
using System.Threading.Tasks;
using Budy.Application.UsersRoles.Commands;
using Budy.Application.UsersRoles.Queries;
using Budy.Application.UsersRoles.Requests;
using Budy.Domain;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    [ApiController]
    //[Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    public class UsersRolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UsersRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRoleRequest request)
        {
            try
            {
                var command = new CreateUserRoleCommand(request.Email, request.RoleId);

                var userEmail = await _mediator.Send(command);
                
                return CreatedAtAction(nameof(Create), new {Email = userEmail});
            }
            catch (Exception exception) when (exception is UserNotFoundException
                || exception is RoleNotFoundException)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var query = new GetUserRoleQuery(email);
            var userRole = await _mediator.Send(query);

            if (userRole is null)
            {
                return NotFound();
            }

            return Ok(userRole);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserRoleRequest request)
        {
            try
            {
                var command = new DeleteUserRoleCommand(request.RoleId, request.Email);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception exception) when(exception is UserRoleNotFoundException
                || exception is RoleNotFoundException)
            {
                return NotFound();
            }
        }
    }
}