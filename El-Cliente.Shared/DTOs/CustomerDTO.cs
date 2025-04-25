using El_Cliente.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace El_Cliente.Shared.DTOs
{
    public class CustomerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surnames { get; set; } = null!;

        public string City { get; set; } = null!;

        public ICollection<Registration>? Registrations { get; set; }

        public ICollection<Balance>? Balances { get; set; }

        public ICollection<Visit>? Visits { get; set; }
    }
}