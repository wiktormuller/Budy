using System;
using System.Threading;
using System.Threading.Tasks;
using Budy.Application.Identity.Commands;
using Budy.Application.Identity.Responses;
using Budy.Domain.Entities;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Budy.Application.Identity.CommandsHandlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly UserManager<User> _userManager;  
        private readonly RoleManager<Role> _roleManager;  
        private readonly IConfiguration _configuration; 
        
        public RegisterCommandHandler(UserManager<User> userManager, 
            RoleManager<Role> roleManager, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        
        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);

            if (existingUser is not null) // User already exists
            {
                throw UserAlreadyExistsException.ForUsername(request.Username);
            }

            var newUser = new User
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };

            var identityResult = await _userManager.CreateAsync(newUser, request.Password);

            var result = new RegisterResponse(identityResult.ToString(), identityResult.Succeeded);

            return result;
        }
    }
}