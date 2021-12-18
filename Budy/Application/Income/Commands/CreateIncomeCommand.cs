using System;
using MediatR;

namespace Budy.Application.Income.Commands
{
    public class CreateIncomeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public int CategoryId { get; set; }
    }
}