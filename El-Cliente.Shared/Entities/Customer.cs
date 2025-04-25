using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.Entities
{
    public class Customer
    {
        public long Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Surnames { get; set; } = null!;

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string City { get; set; } = null!;

        public ICollection<Registration>? Registrations { get; set; }

        public ICollection<Balance>? Balances { get; set; }

        public ICollection<Visit>? Visits { get; set; }
    }
}