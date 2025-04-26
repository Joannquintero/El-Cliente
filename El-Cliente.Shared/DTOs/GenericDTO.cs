using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.DTOs
{
    public class GenericDTO
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Value { get; set; } = null!;
    }
}