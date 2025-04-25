using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace El_Cliente.Shared.Entities
{
    public class Balance
    {
        public long Id { get; set; }

        public Customer Customer { get; set; } = null!;

        public long CustomerId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Saldo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Amount { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}