using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Services.Customer
{
    public interface ICustomerServices
    {
        Task<Response> GetCustomersByBranchIdAsync([FromQuery] PaginationDTO pagination);

        Task<Response> CreateAsync(CustomerDTO customerDTO);
    }
}