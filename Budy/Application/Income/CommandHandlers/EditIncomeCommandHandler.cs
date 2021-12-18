using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Commands;
using MediatR;

namespace Budy.Application.Income.CommandHandlers
{
    public class EditIncomeCommandHandler : IRequestHandler<EditIncomeCommand>
    {
        public EditIncomeCommandHandler()
        {
                
        }

        public Task<Unit> Handle(EditIncomeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}