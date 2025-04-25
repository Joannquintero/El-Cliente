namespace El_Cliente.Shared.DTOs
{
    public class RegistrationDTO
    {
        public int Id { get; set; }

        public string Identifier { get; set; } = Guid.NewGuid().ToString();

        public int ProductId { get; set; }

        public long CustomerId { get; set; }

        public bool IsActive { get; set; }
    }
}