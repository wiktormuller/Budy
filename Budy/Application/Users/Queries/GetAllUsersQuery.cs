using System.Collections.Generic;
using Budy.Application.Users.Responses;
using MediatR;

namespace Budy.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserResponse>>
    {
    }
}