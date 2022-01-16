using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using Budy.Application.Interfaces;
using Budy.Domain.Entities;
using Budy.Domain.Exceptions;
using MediatR;

namespace Budy.Application.Expenses.CommandHandlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, int>
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        
        public CreateExpenseCommandHandler(IExpensesRepository expensesRepository, 
            ICategoriesRepository categoriesRepository)
        {
            _expensesRepository = expensesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            if (!await _categoriesRepository.Exists(request.CategoryId))
            {
                throw CategoryNotFoundException.ForId(request.CategoryId);
            }

            var category = await _categoriesRepository.GetById(request.CategoryId);
            
            var expense = new Expense(request.Name, request.Amount, request.OccuredAt, category);

            var expenseId = await _expensesRepository.Create(expense);

            return expenseId;
        }
    }
}