using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using MediatR;

namespace Budy.Application.Categories.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        public CreateCategoryCommandHandler()
        {
                
        }

        public Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = 123;

            return Task.FromResult(result);
        }
    }
}