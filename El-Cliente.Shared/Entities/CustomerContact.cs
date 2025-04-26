namespace El_Cliente.Shared.Entities
{
    public class CustomerContact
    {
        public int Id { get; set; }

        public Customer Customer { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Value { get; set; } = null!;

        public bool? Notify { get; set; }
    }
}