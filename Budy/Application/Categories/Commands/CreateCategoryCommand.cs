using MediatR;

namespace Budy.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}