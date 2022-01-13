using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Balances.Queries;
using MediatR;

namespace Budy.Application.Balances.QueriesHandlers
{
    public class GetActualBalanceQueryHandler : IRequestHandler<GetActualBalanceQuery, BalanceResponse>
    {
        public GetActualBalanceQueryHandler()
        {
            
        }

        public async Task<BalanceResponse> Handle(GetActualBalanceQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}