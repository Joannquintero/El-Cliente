using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Customer
{
    public interface ICustomerServices
    {
        Task<List<CustomerDTO>> GetCustomersByBranchIdAsync(PaginationDTO pagination);

        Task<double> GetPagesAsync(PaginationDTO pagination);

        Task<Response> GetCustomerByIdAsync(long id);

        Task<Response> CreateAsync(CustomerDTO customerDTO);
    }
}