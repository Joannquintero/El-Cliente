using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;

        [Display(Name = "Tipo de Producto")]
        public string ProductType { get; set; } = null!;

        public ICollection<Registration>? Registrations { get; set; }

        public ICollection<Availability>? Availability { get; set; }
    }
}