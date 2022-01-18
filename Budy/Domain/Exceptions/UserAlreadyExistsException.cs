namespace Budy.Domain.Exceptions
{
    public class UserAlreadyExistsException : System.Exception
    {
        private UserAlreadyExistsException(string message) : base(message) {}

        public static UserAlreadyExistsException ForEmail(string email) =>
            new UserAlreadyExistsException($"User with Email: #'{email}' already exists.");
    }
}