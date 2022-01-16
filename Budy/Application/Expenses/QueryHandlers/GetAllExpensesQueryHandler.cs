using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Queries;
using Budy.Application.Expenses.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Expenses.QueryHandlers
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseResponse>>
    {
        private readonly IExpensesRepository _expensesRepository;
        
        public GetAllExpensesQueryHandler(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task<List<ExpenseResponse>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expensesRepository.GetAll(null);

            var result = expenses
                .Select(x => new ExpenseResponse(x.Id, x.Name, x.Amount, x.OccuredAt, x.Category.Name))
                .ToList();

            return result;
        }
    }
}