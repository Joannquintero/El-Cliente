using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.Entities
{
    public class Transaction
    {
        public long Id { get; set; }

        [Display(Name = "Identificador")]
        public string Identifier { get; set; } = null!;

        public Balance Balance { get; set; } = null!;

        public long BalanceId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}