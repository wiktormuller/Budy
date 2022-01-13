using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Income.Commands;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Income.CommandHandlers
{
    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand>
    {
        private readonly IIncomesRepository _incomesRepository;
        
        public DeleteIncomeCommandHandler(IIncomesRepository incomesRepository)
        {
            _incomesRepository = incomesRepository;
        }

        public async Task<Unit> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            if (! await _incomesRepository.Exists(request.Id))
            {
                // throw IncomeNotFoundException.ForId(request.Id);
                throw new ArgumentException();
            }

            await _incomesRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}