using El_Cliente.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.DTOs
{
    public class CustomerDTO
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

        public decimal Amount { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool EmailCheck { get; set; } = false;

        public bool SMSCheck { get; set; } = false;

        public ICollection<Balance>? Balances { get; set; }
    }
}