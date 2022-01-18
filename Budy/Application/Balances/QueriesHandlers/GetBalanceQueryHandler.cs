using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Balances.Queries;
using Budy.Application.Balances.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Balances.QueriesHandlers
{
    public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, BalanceResponse>
    {
        private readonly IIncomesRepository _incomesRepository;
        private readonly IExpensesRepository _expensesRepository;
        
        public GetBalanceQueryHandler(IIncomesRepository incomesRepository, 
            IExpensesRepository expensesRepository)
        {
            _incomesRepository = incomesRepository;
            _expensesRepository = expensesRepository;
        }

        public async Task<BalanceResponse> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            var expensesUntilRequestedDateTime = await _expensesRepository.GetAll(request.BalanceDateTime);
            var incomesUntilRequestedDateTime = await _incomesRepository.GetAll(request.BalanceDateTime);

            var expensesSum = expensesUntilRequestedDateTime.Select(x => x.Amount).Sum();
            var incomesSum = incomesUntilRequestedDateTime.Select(x => x.Amount).Sum();

            var balance = incomesSum - expensesSum;

            var balanceResponse = new BalanceResponse(balance);

            return balanceResponse;
        }
    }
}