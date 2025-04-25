using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.Entities
{
    public class Visit
    {
        public int Id { get; set; }

        public Branch Branch { get; set; } = null!;

        public int BranchId { get; set; }

        public Customer Customer { get; set; } = null!;

        public long CustomerId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}