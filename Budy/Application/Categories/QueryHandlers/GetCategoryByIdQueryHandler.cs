using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Queries;
using Budy.Application.Categories.Responses;
using Budy.Application.Interfaces;
using Budy.Domain.Exceptions;
using MediatR;

namespace Budy.Application.Categories.QueryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery,CategoryResponse>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public GetCategoryByIdQueryHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _categoriesRepository.Exists(request.Id))
            {
                throw CategoryNotFoundException.ForId(request.Id);
            }
            
            var category = await _categoriesRepository.GetById(request.Id);

            var result = new CategoryResponse(category.Id, category.Name);

            return result;
        }
    }
}