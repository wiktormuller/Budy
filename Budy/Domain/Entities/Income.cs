using System;

namespace Budy.Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public Category Category { get; set; } // One-to-one
    }
}