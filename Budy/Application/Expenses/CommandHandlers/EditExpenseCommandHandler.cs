using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using Budy.Application.Interfaces;
using Budy.Domain.Exceptions;
using MediatR;

namespace Budy.Application.Expenses.CommandHandlers
{
    public class EditExpenseCommandHandler : IRequestHandler<EditExpenseCommand>
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        
        public EditExpenseCommandHandler(IExpensesRepository expensesRepository,
            ICategoriesRepository categoriesRepository)
        {
            _expensesRepository = expensesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(EditExpenseCommand request, CancellationToken cancellationToken)
        {
            if (!await _expensesRepository.Exists(request.Id))
            {
                throw ExpenseNotFoundException.ForId(request.Id);
            }

            if (!await _categoriesRepository.Exists(request.CategoryId))
            {
                throw CategoryNotFoundException.ForId(request.CategoryId);
            }

            var category = await _categoriesRepository.GetById(request.CategoryId);

            var expense = await _expensesRepository.GetById(request.Id);
            expense.BasicUpdate(request.Name, request.Amount, request.OccuredAt, category);


            return Unit.Value;
        }
    }
}