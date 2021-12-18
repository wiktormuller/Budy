using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using MediatR;

namespace Budy.Application.Categories.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandHandler()
        {
            
        }

        public Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}