using System;

namespace Budy.Application.Expenses.Requests
{
    public class CreateExpenseRequest
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public int CategoryId { get; set; }
    }
}