using System;

namespace Budy.Application.Income.Responses
{
    public class IncomeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; } = "income";

        public IncomeResponse(int id, string name, decimal amount, DateTime occuredAt, string categoryName)
        {
            Id = id;
            Name = name;
            Amount = amount;
            OccuredAt = occuredAt;
            CategoryName = categoryName;
        }
    }
}