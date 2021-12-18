using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Commands;
using MediatR;

namespace Budy.Application.Expenses.CommandHandlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, int>
    {
        public CreateExpenseCommandHandler()
        {
            
        }

        public Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var result = 123;

            return Task.FromResult(result);
        }
    }
}