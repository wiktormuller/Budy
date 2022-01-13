using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Queries;
using Budy.Application.Income.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Income.QueryHandlers
{
    public class GetIncomeByIdQueryHandler : IRequestHandler<GetIncomeByIdQuery, IncomeResponse>
    {
        private readonly IIncomesRepository _incomesRepository;
        
        public GetIncomeByIdQueryHandler(IIncomesRepository incomesRepository)
        {
            _incomesRepository = incomesRepository;
        }

        public async Task<IncomeResponse> Handle(GetIncomeByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _incomesRepository.Exists(request.Id))
            {
                throw new ArgumentException(nameof(request.Id));
                // @TODO Throw Domain Exception
            }
            
            var income = await _incomesRepository.GetById(request.Id);

            var result = new IncomeResponse(income.Id, income.Name, income.Amount, income.OccuredAt,
                income.Category.Name);

            return result;
        }
    }
}