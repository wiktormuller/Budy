using System.Collections.Generic;
using Budy.Application.UsersRoles.Responses;
using MediatR;

namespace Budy.Application.UsersRoles.Queries
{
    public class GetUserRoleQuery : IRequest<List<UserRoleResponse>>
    {
        public string Email { get; private set; }

        public GetUserRoleQuery(string email)
        {
            Email = email;
        }
    }
}