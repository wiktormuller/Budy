using MediatR;

namespace Budy.Application.Expenses.Commands
{
    public class DeleteExpenseCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteExpenseCommand(int id)
        {
            Id = id;
        }
    }
}