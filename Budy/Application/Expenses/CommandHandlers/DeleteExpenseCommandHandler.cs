using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using Budy.Application.Interfaces;
using Budy.Domain.Exceptions;
using MediatR;

namespace Budy.Application.Expenses.CommandHandlers
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
    {
        private readonly IExpensesRepository _expensesRepository;
        
        public DeleteExpenseCommandHandler(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            if (!await _expensesRepository.Exists(request.Id))
            {
                throw ExpenseNotFoundException.ForId(request.Id);
            }

            await _expensesRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}