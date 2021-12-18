using Budy.Application.Income.Responses;
using MediatR;

namespace Budy.Application.Income.Queries
{
    public class GetIncomeByIdQuery : IRequest<IncomeResponse>
    {
        public int Id { get; set; }

        public GetIncomeByIdQuery(int id)
        {
            Id = id;
        }
    }
}