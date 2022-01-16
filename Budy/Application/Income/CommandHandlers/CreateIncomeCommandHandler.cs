using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Commands;
using Budy.Application.Interfaces;
using Budy.Domain.Exceptions;
using Budy.Infrastructure.Repositories;
using MediatR;

namespace Budy.Application.Income.CommandHandlers
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, int>
    {
        private readonly IIncomesRepository _incomesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        
        public CreateIncomeCommandHandler(IIncomesRepository incomesRepository, 
            ICategoriesRepository categoriesRepository)
        {
            _incomesRepository = incomesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<int> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            if (!await _categoriesRepository.Exists(request.CategoryId))
            {
                throw CategoryNotFoundException.ForId(request.CategoryId);
            }

            var category = await _categoriesRepository.GetById(request.CategoryId);

            var income = new Domain.Entities.Income(request.Name, request.Amount, request.OccuredAt, category);

            var incomeId = await _incomesRepository.Create(income);

            return incomeId;
        }
    }
}