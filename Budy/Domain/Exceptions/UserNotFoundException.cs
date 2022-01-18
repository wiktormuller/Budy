using Budy.Identity;

namespace Budy.Domain.Exceptions
{
    public class UserNotFoundException : System.Exception
    {
        private UserNotFoundException(string message) : base(message) {}

        public static UserNotFoundException Default() =>
            new UserNotFoundException($"Username or password is incorrect.");

        public static UserNotFoundException ForEmail(string email) =>
            new UserNotFoundException($"User with email: #'{email} was not found.'");
    }
}