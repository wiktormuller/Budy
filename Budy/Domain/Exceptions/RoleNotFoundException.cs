namespace Budy.Domain.Exceptions
{
    public class RoleNotFoundException : System.Exception
    {
        private RoleNotFoundException(string message) : base(message) {}

        public static RoleNotFoundException ForId(int id) =>
            new RoleNotFoundException($"Role with Id: #{id} not found.");
    }
}