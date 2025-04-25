using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Balance;
using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Balance
{
    public class BalanceServices : IBalanceServices
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceServices(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public async Task<Shared.Entities.Balance> GetByCustomerIdAsync(long customerId)
        {
            var balance = await _balanceRepository.GetByCustomerIdAsync(customerId);
            return balance!;
        }

        public async Task<Response> CreateAsync(BalanceDTO balanceDTO)
        {
            Response response = new();
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<BalanceDTO, Shared.Entities.Balance>(balanceDTO);
                await _balanceRepository.CreateAsync(entity);

                response.IsSuccess = true;
                response.Result = balanceDTO;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response> UpdateAsync(BalanceDTO balanceDTO)
        {
            Response response = new();
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<BalanceDTO, Shared.Entities.Balance>(balanceDTO);
                await _balanceRepository.UpdateAsync(entity);

                response.IsSuccess = true;
                response.Result = balanceDTO;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}