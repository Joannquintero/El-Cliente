using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Balance
{
    public interface IBalanceServices
    {
        Task<Shared.Entities.Balance> GetByCustomerIdAsync(long customerId);

        Task<BalanceDTO> CreateAsync(BalanceDTO balanceDTO);

        Task<BalanceDTO> UpdateAsync(BalanceDTO balanceDTO);
    }
}