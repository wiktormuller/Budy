using System;

namespace Budy.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public Category Category { get; set; }

        private Expense() { }

        public Expense(string name, decimal amount, DateTime occuredAt, Category category)
        {
            Name = name;
            Amount = amount;
            OccuredAt = occuredAt;
            Category = category;
        }

        public void BasicUpdate(string name, decimal amount, DateTime occuredAt, Category category)
        {
            Name = name;
            Amount = amount;
            OccuredAt = occuredAt;
            Category = category;
        }
    }
}