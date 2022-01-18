using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Users.Responses;
using Budy.Application.Users.Queries;
using Budy.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Budy.Application.Users.QueriesHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserResponse>>
    {
        private readonly UserManager<User> _userManager;
        
        public GetAllUsersQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<List<UserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();

            var response = users
                .Select(user => new UserResponse(user.Email, user.UserName, user.EmailConfirmed))
                .ToList();

            return response;
        }
    }
}