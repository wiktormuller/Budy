using System;

namespace Budy.Application.Income.Filters
{
    public class GetAllIncomesFilter
    {
        public int? CategoryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}