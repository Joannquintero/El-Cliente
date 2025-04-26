using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Customer
{
    public interface ICustomerServices
    {
        Task<List<CustomerDTO>> GetCustomersByBranchIdAsync(PaginationDTO pagination);

        Task<double> GetPagesAsync(PaginationDTO pagination);

        Task<CustomerDTO> GetCustomerByIdAsync(long id);

        Task<CustomerDTO> CreateAsync(CustomerDTO customerDTO);
    }
}