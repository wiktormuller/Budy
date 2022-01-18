using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Roles.Queries;
using Budy.Application.Roles.Responses;
using Budy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Budy.Application.Roles.QueriesHandlers
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleResponse>>
    {
        private readonly RoleManager<Role> _roleManager;
        
        public GetAllRolesQueryHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();

            var response = roles
                .Select(role => new RoleResponse(role.Id, role.Name))
                .ToList();

            return response;
        }
    }
}