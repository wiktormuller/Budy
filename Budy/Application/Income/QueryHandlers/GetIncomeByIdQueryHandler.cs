using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Queries;
using Budy.Application.Income.Responses;
using MediatR;

namespace Budy.Application.Income.QueryHandlers
{
    public class GetIncomeByIdQueryHandler : IRequestHandler<GetIncomeByIdQuery, IncomeResponse>
    {
        public GetIncomeByIdQueryHandler()
        {
            
        }

        public Task<IncomeResponse> Handle(GetIncomeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new IncomeResponse();

            return Task.FromResult(result);
        }
    }
}