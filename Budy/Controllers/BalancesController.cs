using System.Collections.Generic;
using System.Threading.Tasks;
using Budy.Application.Balances;
using Budy.Application.Balances.Filters;
using Budy.Application.Balances.Queries;
using Budy.Application.Expenses.Filters;
using Budy.Application.Expenses.Queries;
using Budy.Application.Expenses.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BalancesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("/actual")]
        public async Task<ActionResult<BalanceResponse>> GetActualBalance()
        {
            var query = new GetActualBalanceQuery();
            
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        public async Task<ActionResult<BalanceResponse>> GetBalanace(GetBalanceFilter filter)
        {
            var query = new GetBalanceQuery();

            return Ok(await _mediator.Send(query));
        }
    }
}