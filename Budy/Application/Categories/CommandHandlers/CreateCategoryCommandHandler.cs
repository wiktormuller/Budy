using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using Budy.Application.Interfaces;
using Budy.Domain.Entities;
using MediatR;

namespace Budy.Application.Categories.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        
        public CreateCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            var categoryId = await _categoriesRepository.Create(category);

            return categoryId;
        }
    }
}