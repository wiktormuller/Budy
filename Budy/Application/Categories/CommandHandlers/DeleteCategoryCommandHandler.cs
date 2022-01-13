using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using Budy.Infrastructure.Repositories;
using MediatR;

namespace Budy.Application.Categories.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly CategoriesRepository _categoriesRepository;
        
        public DeleteCategoryCommandHandler(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!await _categoriesRepository.Exists(request.Id))
            {
                //throw CategoryNotFoundException.ForId(request.Id);
                throw new ArgumentException();
            }
            
            await _categoriesRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}