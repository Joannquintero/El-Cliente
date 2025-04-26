namespace El_Cliente.Shared.DTOs
{
    public class CustomerContactDTO
    {
        public int Id { get; set; }

        public long CustomerId { get; set; }

        public string Type { get; set; } = null!;

        public string Value { get; set; } = null!;

        public bool? Notify { get; set; }
    }
}