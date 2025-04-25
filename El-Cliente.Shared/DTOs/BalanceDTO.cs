namespace El_Cliente.Shared.DTOs
{
    public class BalanceDTO
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public decimal Amount { get; set; }
    }
}