using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Commands;
using MediatR;

namespace Budy.Application.Income.CommandHandlers
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, int>
    {
        public CreateIncomeCommandHandler()
        {
                
        }

        public int Handle(CreateIncomeCommand command)
        {
            return 123;
        }

        public Task<int> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var result = 123;

            return Task.FromResult(result);
        }
    }
}