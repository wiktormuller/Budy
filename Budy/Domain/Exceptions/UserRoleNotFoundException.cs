namespace Budy.Domain.Exceptions
{
    public class UserRoleNotFoundException : System.Exception
    {
        private UserRoleNotFoundException(string message) : base(message) {}

        public static UserRoleNotFoundException ForEmail(string email) =>
            new UserRoleNotFoundException($"User role for user with Email: #'{email} was not found.'");
    }
}