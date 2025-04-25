using El_Cliente.Shared.Entities;

namespace El_Cliente.Shared.DTOs
{
    public class RegistrationDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public long CustomerId { get; set; }

        public bool IsActive { get; set; }
    }
}