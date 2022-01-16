using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Commands;
using Budy.Application.Interfaces;
using Budy.Domain.Exceptions;
using MediatR;

namespace Budy.Application.Income.CommandHandlers
{
    public class EditIncomeCommandHandler : IRequestHandler<EditIncomeCommand>
    {
        private readonly IIncomesRepository _incomesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        
        public EditIncomeCommandHandler(IIncomesRepository incomesRepository, 
            ICategoriesRepository categoriesRepository)
        {
            _incomesRepository = incomesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(EditIncomeCommand request, CancellationToken cancellationToken)
        {
            if (!await _categoriesRepository.Exists(request.CategoryId))
            {
                throw CategoryNotFoundException.ForId(request.Id);
            }
            
            if (!await _categoriesRepository.Exists(request.CategoryId))
            {
                throw CategoryNotFoundException.ForId(request.CategoryId);
            }

            var income = await _incomesRepository.GetById(request.Id);

            var category = await _categoriesRepository.GetById(request.CategoryId);

            income.BasicUpdate(request.Name, request.Amount, request.OccuredAt, category);
            
            await _incomesRepository.Update();

            return Unit.Value;
        }
    }
}