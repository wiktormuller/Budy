using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Commands;
using MediatR;

namespace Budy.Application.Income.CommandHandlers
{
    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand>
    {
        public DeleteIncomeCommandHandler()
        {
            
        }

        public Task<Unit> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}