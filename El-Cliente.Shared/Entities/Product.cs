using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace El_Cliente.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Monto Mínimo")]
        [Required]
        public decimal MinimumAmount { get; set; }

        [Display(Name = "Categoría")]
        [MaxLength(10)]
        [Required]
        public string Category { get; set; } = null!;

        public ICollection<Registration>? Registrations { get; set; }

        public ICollection<Availability>? Availability { get; set; }
    }
}