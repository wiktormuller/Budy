namespace Budy.Application.Balances
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