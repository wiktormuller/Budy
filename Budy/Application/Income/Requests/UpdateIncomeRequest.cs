using System;

namespace Budy.Application.Income.Requests
{
    public class UpdateIncomeRequest
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public int CategoryId { get; set; }
    }
}