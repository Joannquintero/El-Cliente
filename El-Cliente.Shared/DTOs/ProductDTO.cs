using El_Cliente.Shared.Entities;

namespace El_Cliente.Shared.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal MinimumAmount { get; set; }

        public string Category { get; set; } = null!;

        public ICollection<Registration>? Registrations { get; set; }

        public ICollection<Availability>? Availability { get; set; }
    }
}