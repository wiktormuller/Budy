namespace Budy.Application.Users.Responses
{
    public class UserResponse
    {
        public string Email { get; private set; }
        public string Username { get; private set; }
        public bool IsEmailConfirmed { get; private set; }
        
        public UserResponse(string email, string username, bool isEmailConfirmed)
        {
            Email = email;
            Username = username;
            IsEmailConfirmed = isEmailConfirmed;
        }
    }
}