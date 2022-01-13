using System;

namespace Budy.Application.Expenses.Filters
{
    public class GetAllExpensesFilter
    {
        public int? CategoryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}