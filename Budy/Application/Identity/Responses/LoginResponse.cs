using System;

namespace Budy.Application.Identity.Responses
{
    public class LoginResponse
    {
        public string Token { get; private set; }
        public DateTime Expiration { get; private set; }
        
        public LoginResponse(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}