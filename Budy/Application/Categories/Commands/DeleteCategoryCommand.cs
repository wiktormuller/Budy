using MediatR;

namespace Budy.Application.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}