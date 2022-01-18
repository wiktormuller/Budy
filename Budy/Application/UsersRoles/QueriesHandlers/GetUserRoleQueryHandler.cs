using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.UsersRoles.Queries;
using Budy.Application.UsersRoles.Responses;
using Budy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Budy.Application.UsersRoles.QueriesHandlers
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, List<UserRoleResponse>>
    {
        private readonly UserManager<User> _userManager;
        
        public GetUserRoleQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<List<UserRoleResponse>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var response = userRoles
                .Select(userRoleName => new UserRoleResponse(userRoleName))
                .ToList();

            return response;
        }
    }
}