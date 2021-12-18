using System;
using MediatR;

namespace Budy.Application.Income.Commands
{
    public class EditIncomeCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public int CategoryId { get; set; }
    }
}