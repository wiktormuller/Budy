using System.Collections.Generic;
using Budy.Application.Categories.Responses;
using MediatR;

namespace Budy.Application.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryResponse>>
    {
        
    }
}