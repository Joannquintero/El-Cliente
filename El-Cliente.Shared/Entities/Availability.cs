namespace El_Cliente.Shared.Entities
{
    public class Availability
    {
        public int Id { get; set; }

        public Branch Branch { get; set; } = null!;

        public int BranchId { get; set; }

        public Product Product { get; set; } = null!;

        public long ProductId { get; set; }
    }
}