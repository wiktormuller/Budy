using MediatR;

namespace Budy.Application.Roles.Commands
{
    public class CreateRoleCommand : IRequest<int>
    {
        public string Name { get; private set; }

        public CreateRoleCommand(string name)
        {
            Name = name;
        }
    }
}