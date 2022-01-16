namespace Budy.Domain.Exceptions
{
    public class ExpenseNotFoundException : System.Exception
    {
        private ExpenseNotFoundException(string message) : base(message) {}

        public static ExpenseNotFoundException ForId(int id) =>
            new($"Expense with Id: #{id} not found.");
    }
}