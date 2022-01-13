using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Queries;
using Budy.Application.Categories.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Categories.QueryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
    {
        private readonly ICategoriesRepository _categoriesRepository;
        
        public GetAllCategoriesQueryHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoriesRepository.GetAll();

            var result = categories
                .Select(x => new CategoryResponse(x.Id, x.Name))
                .ToList();

            return result;
        }
    }
}