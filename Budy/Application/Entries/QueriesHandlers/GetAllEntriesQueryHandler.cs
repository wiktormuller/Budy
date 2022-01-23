using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Entries.Queries;
using Budy.Application.Entries.Responses;
using Budy.Application.Interfaces;
using MediatR;

namespace Budy.Application.Entries.QueriesHandlers
{
    public class GetAllEntriesQueryHandler : IRequestHandler<GetAllEntriesQuery, List<EntryResponse>>
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IIncomesRepository _incomesRepository;
        
        public GetAllEntriesQueryHandler(IExpensesRepository expensesRepository, 
            IIncomesRepository incomesRepository)
        {
            _expensesRepository = expensesRepository;
            _incomesRepository = incomesRepository;
        }
        
        public async Task<List<EntryResponse>> Handle(GetAllEntriesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expensesRepository.GetAll(null);
            var incomes = await _incomesRepository.GetAll(null);

            var expenseResponse = expenses.Select(expense => new EntryResponse(
                expense.Id, expense.Name, expense.Amount, expense.OccuredAt, "expense"));

            var incomeResponse = incomes.Select(income => new EntryResponse(
                income.Id, income.Name, income.Amount, income.OccuredAt, "income"));

            var result = expenseResponse.Concat(incomeResponse).ToList();
            result = result.OrderByDescending(entry => entry.OccuredAt).ToList();

            return result;
        }
    }
}