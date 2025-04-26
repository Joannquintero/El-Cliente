namespace El_Cliente.Api.Repository.CustomerContact
{
    public interface ICustomerContactRepository
    {
        Task<Shared.Entities.CustomerContact> CreateAsync(Shared.Entities.CustomerContact customerContact);

        Task<List<Shared.Entities.CustomerContact>> GetByCustomerIdAsync(long customerId);
    }
}