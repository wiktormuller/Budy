using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using MediatR;

namespace Budy.Application.Expenses.CommandHandlers
{
    public class EditExpenseCommandHandler : IRequestHandler<EditExpenseCommand>
    {
        public EditExpenseCommandHandler()
        {
            
        }

        public Task<Unit> Handle(EditExpenseCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}