using Budy.Application.Expenses.Responses;
using MediatR;

namespace Budy.Application.Expenses.Queries
{
    public class GetExpenseByIdQuery : IRequest<ExpenseResponse>
    {
        public int Id { get; set; }

        public GetExpenseByIdQuery(int id)
        {
            Id = id;
        }
    }
}