using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Balance
{
    public interface IBalanceServices
    {
        Task<Shared.Entities.Balance> GetByCustomerIdAsync(long customerId);

        Task<Response> CreateAsync(BalanceDTO balanceDTO);

        Task<Response> UpdateAsync(BalanceDTO balanceDTO);
    }
}