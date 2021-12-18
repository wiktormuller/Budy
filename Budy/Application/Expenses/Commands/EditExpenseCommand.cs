using System;
using MediatR;

namespace Budy.Application.Expenses.Commands
{
    public class EditExpenseCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OccuredAt { get; set; }
        public int CategoryId { get; set; }
    }
}