using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Balances.Queries;
using MediatR;

namespace Budy.Application.Balances.QueriesHandlers
{
    public class GetBalanceQueryHandler : IRequestHandler<GetBalanceQuery, BalanceResponse>
    {
        public GetBalanceQueryHandler()
        {
            
        }

        public async Task<BalanceResponse> Handle(GetBalanceQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}