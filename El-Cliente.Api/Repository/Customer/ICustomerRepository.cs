using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Repository.Customer
{
    public interface ICustomerRepository
    {
        Task<List<Shared.Entities.Customer>> GetCustomersByBranchIdAsync([FromQuery] PaginationDTO pagination);

        Task<Shared.Entities.Customer> CreateAsync(Shared.Entities.Customer customer);
    }
}