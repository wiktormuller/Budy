using System.Collections.Generic;
using Budy.Application.Roles.Responses;
using MediatR;

namespace Budy.Application.Roles.Queries
{
    public class GetAllRolesQuery : IRequest<List<RoleResponse>>
    {
    }
}