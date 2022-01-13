using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using Budy.Infrastructure.Repositories;
using MediatR;

namespace Budy.Application.Expenses.CommandHandlers
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
    {
        private readonly ExpensesRepository _expensesRepository;
        
        public DeleteExpenseCommandHandler(ExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            if (!await _expensesRepository.Exists(request.Id))
            {
                // throw ExpenseNotFoundException.ForId(request.Id);
                throw new ArgumentException();
            }

            await _expensesRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}