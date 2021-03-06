using System.Threading.Tasks;
using Budy.Application.Users.Queries;
using Budy.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    [ApiController]
    //[Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();

            return Ok(await _mediator.Send(query));
        }
    }
}