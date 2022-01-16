namespace Budy.Domain.Exceptions
{
    public class UserAlreadyExistsException : System.Exception
    {
        private UserAlreadyExistsException(string message) : base(message) {}

        public static UserAlreadyExistsException ForUsername(string username) =>
            new UserAlreadyExistsException($"User with Username: #'{username}' already exists.");
    }
}