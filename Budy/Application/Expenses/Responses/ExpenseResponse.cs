using System;

namespace Budy.Application.Expenses.Responses
{
    public class ExpenseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; } = "expense";

        public ExpenseResponse(int id, string name, decimal amount, DateTime occuredAt, string categoryName)
        {
            Id = id;
            Name = name;
            Amount = amount;
            OccuredAt = occuredAt;
            CategoryName = categoryName;
        }
    }
}