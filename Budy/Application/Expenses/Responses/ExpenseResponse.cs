namespace Budy.Application.Expenses.Responses
{
    public class ExpenseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; } // Maybe return category name?
    }
}