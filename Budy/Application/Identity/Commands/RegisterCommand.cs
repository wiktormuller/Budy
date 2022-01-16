using Budy.Application.Identity.Responses;
using MediatR;

namespace Budy.Application.Identity.Commands
{
    public class RegisterCommand : IRequest<RegisterResponse>
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        
        public RegisterCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
    }
}