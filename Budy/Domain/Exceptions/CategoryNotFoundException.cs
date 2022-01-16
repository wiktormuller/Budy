namespace Budy.Domain.Exceptions
{
    public class CategoryNotFoundException : System.Exception
    {
        private CategoryNotFoundException(string message) : base(message) {}

        public static CategoryNotFoundException ForId(int id) =>
            new($"Category with Id: #{id} not found.");
    }
}