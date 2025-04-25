using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Balance
{
    public interface IBalanceServices
    {
        Task<Response> UpdateAsync(BalanceDTO balanceDTO);
    }
}