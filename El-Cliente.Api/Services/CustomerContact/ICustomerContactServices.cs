using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.CustomerContact
{
    public interface ICustomerContactServices
    {
        Task<List<CustomerContactDTO>> GetCustomerContactByCustomerIdAsync(long customerId);

        Task<CustomerContactDTO> CreateAsync(CustomerContactDTO customerContact);
    }
}