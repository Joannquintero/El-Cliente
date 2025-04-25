namespace El_Cliente.Shared.Entities
{
    public class Registration
    {
        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        public Customer Customer { get; set; } = null!;

        public long CustomerId { get; set; }
    }
}