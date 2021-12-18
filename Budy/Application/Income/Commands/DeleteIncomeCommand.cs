using MediatR;

namespace Budy.Application.Income.Commands
{
    public class DeleteIncomeCommand : IRequest
    {
        public int Id { get; set; }
    }
}