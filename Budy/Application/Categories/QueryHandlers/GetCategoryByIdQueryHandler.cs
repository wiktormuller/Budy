using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Categories.Queries;
using Budy.Application.Categories.Responses;
using MediatR;

namespace Budy.Application.Categories.QueryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery,CategoryResponse>
    {
        public Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new CategoryResponse();

            return Task.FromResult(result);
        }
    }
}