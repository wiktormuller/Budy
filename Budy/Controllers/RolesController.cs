using System;
using System.Net;
using System.Threading.Tasks;
using Budy.Application.Roles.Commands;
using Budy.Application.Roles.Queries;
using Budy.Application.Roles.Requests;
using Budy.Domain;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllRolesQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var command = new CreateRoleCommand(request.Name);
                var roleId = await _mediator.Send(command);
                
                return StatusCode((int)HttpStatusCode.Created, new {Id = roleId});
            }
            catch (RoleAlreadyExistsException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}