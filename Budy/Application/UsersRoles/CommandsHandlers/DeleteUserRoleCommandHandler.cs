using System.Threading;
using System.Threading.Tasks;
using Budy.Application.UsersRoles.Commands;
using Budy.Domain.Entities;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Budy.Application.UsersRoles.CommandsHandlers
{
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        
        public DeleteUserRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public async Task<Unit> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw UserNotFoundException.ForEmail(request.Email);
            }

            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (role is null)
            {
                throw RoleNotFoundException.ForId(request.RoleId);
            }

            await _userManager.RemoveFromRoleAsync(user, role.Name);

            return Unit.Value;
        }
    }
}