using Budy.Application.Identity.Responses;
using MediatR;

namespace Budy.Application.Identity.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}