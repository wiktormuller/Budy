using MediatR;

namespace Budy.Application.UsersRoles.Commands
{
    public class CreateUserRoleCommand : IRequest<string>
    {
        public string Email { get; private set; }
        public int RoleId { get; private set; }
        
        public CreateUserRoleCommand(string email, int roleId)
        {
            Email = email;
            RoleId = roleId;
        }
    }
}