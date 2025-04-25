using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.Entities
{
    public class Branch
    {
        public int Id { get; set; }

        [Display(Name = "Sucursal")]
        public string Name { get; set; } = null!;

        [Display(Name = "Ciudad")]
        public string City { get; set; } = null!;

        public ICollection<Visit>? Visits { get; set; }

        public ICollection<Availability>? Availability { get; set; }
    }
}