using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Queries;
using Budy.Application.Income.Responses;
using MediatR;

namespace Budy.Application.Income.QueryHandlers
{
    public class GetAllIncomeQueryHandler : IRequestHandler<GetAllIncomeQuery, List<IncomeResponse>>
    {
        public GetAllIncomeQueryHandler()
        {
                
        }

        public Task<List<IncomeResponse>> Handle(GetAllIncomeQuery request, CancellationToken cancellationToken)
        {
            var result = new List<IncomeResponse>();

            return Task.FromResult(result);
        }
    }
}