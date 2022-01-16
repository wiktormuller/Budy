using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using Budy.Application.Interfaces;
using Budy.Domain.Exceptions;
using MediatR;

namespace Budy.Application.Categories.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        
        public DeleteCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!await _categoriesRepository.Exists(request.Id))
            {
                throw CategoryNotFoundException.ForId(request.Id);
            }
            
            await _categoriesRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}