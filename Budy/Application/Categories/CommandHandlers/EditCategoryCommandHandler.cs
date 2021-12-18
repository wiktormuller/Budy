using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using MediatR;

namespace Budy.Application.Categories.CommandHandlers
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand>
    {
        public EditCategoryCommandHandler()
        {
            
        }

        public Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}