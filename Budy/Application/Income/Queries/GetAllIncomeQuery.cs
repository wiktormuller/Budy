using System.Collections.Generic;
using Budy.Application.Income.Responses;
using MediatR;

namespace Budy.Application.Income.Queries
{
    public class GetAllIncomeQuery : IRequest<List<IncomeResponse>>
    {
        
    }
}