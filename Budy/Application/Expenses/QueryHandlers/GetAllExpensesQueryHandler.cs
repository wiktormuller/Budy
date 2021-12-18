using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Queries;
using Budy.Application.Expenses.Responses;
using MediatR;

namespace Budy.Application.Expenses.QueryHandlers
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseResponse>>
    {
        public GetAllExpensesQueryHandler()
        {
            
        }

        public Task<List<ExpenseResponse>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<ExpenseResponse>();

            return Task.FromResult(result);
        }
    }
}