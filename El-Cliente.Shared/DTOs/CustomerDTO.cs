using El_Cliente.Shared.Entities;

namespace El_Cliente.Shared.DTOs
{
    public class CustomerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surnames { get; set; } = null!;

        public string City { get; set; } = null!;

        public decimal Amount { get; set; }

        public ICollection<Balance>? Balances { get; set; }
    }
}