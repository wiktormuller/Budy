using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Queries;
using Budy.Application.Income.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Income.QueryHandlers
{
    public class GetAllIncomesQueryHandler : IRequestHandler<GetAllIncomesQuery, List<IncomeResponse>>
    {
        private readonly IIncomesRepository _incomesRepository;
        
        public GetAllIncomesQueryHandler(IIncomesRepository incomesRepository)
        {
            _incomesRepository = incomesRepository;
        }

        public async Task<List<IncomeResponse>> Handle(GetAllIncomesQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _incomesRepository.GetAll(null);

            var result = incomes
                .Select(x => new IncomeResponse(x.Id, x.Name, x.Amount, x.OccuredAt, x.Category.Name))
                .ToList();

            return result;
        }
    }
}