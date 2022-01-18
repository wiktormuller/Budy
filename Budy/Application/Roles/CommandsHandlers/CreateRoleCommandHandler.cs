using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Roles.Commands;
using Budy.Domain.Entities;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Budy.Application.Roles.CommandsHandlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly RoleManager<Role> _roleManager;
        
        public CreateRoleCommandHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        
        public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.RoleExistsAsync(request.Name);

            if (roleExists)
            {
                throw RoleAlreadyExistsException.ForName(request.Name);
            }

            var newRole = new Role(request.Name);
            await _roleManager.CreateAsync(newRole);

            return newRole.Id;
        }
    }
}