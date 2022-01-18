namespace Budy.Application.Balances.Responses
{
    public class BalanceResponse
    {
        public decimal BalanceAmount { get; set; }

        public BalanceResponse(decimal balanceAmount)
        {
            BalanceAmount = balanceAmount;
        }
    }
}