using MediatR;

namespace Budy.Application.Categories.Commands
{
    public class EditCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}