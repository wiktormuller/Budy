using System.Threading.Tasks;
using Budy.Application.Entries.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public EntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEntriesQuery();

            return Ok(await _mediator.Send(query));
        }
    }
}