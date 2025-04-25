using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.Entities
{
    public class Registration
    {
        public int Id { get; set; }

        [Display(Name = "Identificador")]
        public string Identifier { get; set; } = Guid.NewGuid().ToString();

        public Product Product { get; set; } = null!;

        public int ProductId { get; set; }

        public Customer Customer { get; set; } = null!;

        public long CustomerId { get; set; }

        public bool IsActive { get; set; }
    }
}