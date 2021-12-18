using Budy.Application.Categories.Responses;
using MediatR;

namespace Budy.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponse>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}