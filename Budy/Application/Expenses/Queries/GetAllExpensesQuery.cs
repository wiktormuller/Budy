using System.Collections.Generic;
using Budy.Application.Expenses.Responses;
using MediatR;

namespace Budy.Application.Expenses.Queries
{
    public class GetAllExpensesQuery : IRequest<List<ExpenseResponse>>
    {
        
    }
}