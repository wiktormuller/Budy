using System;

namespace Budy.Application.Income.Responses
{
    public class IncomeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public int CategoryId { get; set; }
    }
}