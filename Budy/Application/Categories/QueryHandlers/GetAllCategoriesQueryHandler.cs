using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Queries;
using Budy.Application.Categories.Responses;
using MediatR;

namespace Budy.Application.Categories.QueryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
    {
        public GetAllCategoriesQueryHandler()
        {
            
        }

        public Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CategoryResponse>();

            return Task.FromResult(result);
        }
    }
}