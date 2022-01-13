using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Expenses.Queries;
using Budy.Application.Expenses.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Expenses.QueryHandlers
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseResponse>
    {
        private readonly IExpensesRepository _expensesRepository;
        
        public GetExpenseByIdQueryHandler(IExpensesRepository expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task<ExpenseResponse> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await _expensesRepository.Exists(request.Id))
            {
                throw new ArgumentException(nameof(request.Id));
                // @TODO Throw Domain Exception
            }
            
            var expense = await _expensesRepository.GetById(request.Id);
            
            var result = new ExpenseResponse(expense.Id, expense.Name, expense.Amount, expense.OccuredAt, expense.Category.Name);

            return result;
        }
    }
}