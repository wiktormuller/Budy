namespace Budy.Domain.Exceptions
{
    public class IncomeNotFoundException : System.Exception
    {
        private IncomeNotFoundException(string message) : base(message) {}

        public static IncomeNotFoundException ForId(int id) =>
            new($"Income with Id: #{id} not found.");
    }
}