using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Queries;
using Budy.Application.Expenses.Responses;
using MediatR;

namespace Budy.Application.Expenses.QueryHandlers
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseResponse>
    {
        public GetExpenseByIdQueryHandler()
        {
            
        }

        public Task<ExpenseResponse> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new ExpenseResponse();
            
            return Task.FromResult(result);
        }
    }
}