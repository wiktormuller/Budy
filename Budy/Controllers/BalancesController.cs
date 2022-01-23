using System.Threading.Tasks;
using Budy.Application.Balances.Filters;
using Budy.Application.Balances.Queries;
using Budy.Application.Balances.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BalancesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BalancesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("actual")]
        public async Task<ActionResult<BalanceResponse>> GetActualBalance()
        {
            var query = new GetActualBalanceQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<BalanceResponse>> GetBalance(GetBalanceFilter filter)
        {
            var query = new GetBalanceQuery(filter.BalanceDateTime);

            return Ok(await _mediator.Send(query));
        }
    }
}