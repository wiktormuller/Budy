using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Balances.Queries;
using Budy.Application.Balances.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Balances.QueriesHandlers
{
    public class GetActualBalanceQueryHandler : IRequestHandler<GetActualBalanceQuery, BalanceResponse>
    {
        private readonly IIncomesRepository _incomesRepository;
        private readonly IExpensesRepository _expensesRepository;
        
        public GetActualBalanceQueryHandler(IIncomesRepository incomesRepository, 
            IExpensesRepository expensesRepository)
        {
            _incomesRepository = incomesRepository;
            _expensesRepository = expensesRepository;
        }

        public async Task<BalanceResponse> Handle(GetActualBalanceQuery request, CancellationToken cancellationToken)
        {
            var expensesUntilNow = await _expensesRepository.GetAll(null);
            var incomesUntilNow = await _incomesRepository.GetAll(null);

            var expensesSum = expensesUntilNow.Select(x => x.Amount).Sum();
            var incomesSum = incomesUntilNow.Select(x => x.Amount).Sum();

            var balance = incomesSum - expensesSum;

            var balanceResponse = new BalanceResponse(balance);

            return balanceResponse;
        }
    }
}