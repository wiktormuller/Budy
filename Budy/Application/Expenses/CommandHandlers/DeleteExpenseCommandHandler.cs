using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using MediatR;

namespace Budy.Application.Expenses.CommandHandlers
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand>
    {
        public DeleteExpenseCommandHandler()
        {
            
        }

        public Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}