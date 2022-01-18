using MediatR;

namespace Budy.Application.UsersRoles.Commands
{
    public class DeleteUserRoleCommand : IRequest
    {
        public int RoleId { get; private set; }
        public string Email { get; private set; }

        public DeleteUserRoleCommand(int roleId, string email)
        {
            Email = email;
        }
    }
}