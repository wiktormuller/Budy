using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Commands;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Categories.CommandHandlers
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        
        public EditCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            if (! await _categoriesRepository.Exists(request.Id))
            {
                //return CategoryNotFoundException.ForId(request.Id);
                throw new ArgumentException();
            }
            
            var category = await _categoriesRepository.GetById(request.Id);

            category.UpdateName(request.Name);
            await _categoriesRepository.Update();
            
            return Unit.Value;
        }
    }
}