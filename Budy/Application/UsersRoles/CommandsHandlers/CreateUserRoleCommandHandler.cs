using System.Threading;
using System.Threading.Tasks;
using Budy.Application.UsersRoles.Commands;
using Budy.Domain.Entities;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Budy.Application.UsersRoles.CommandsHandlers
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        
        public CreateUserRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public async Task<string> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
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

            await _userManager.AddToRoleAsync(user, role.Name);

            return user.Email;
        }
    }
}