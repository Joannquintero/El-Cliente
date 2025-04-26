using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Balance;
using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Balance
{
    public class BalanceServices : IBalanceServices
    {
        private readonly ILogger<BalanceServices> _logger;
        private readonly IBalanceRepository _balanceRepository;

        public BalanceServices(
            ILogger<BalanceServices> logger,
            IBalanceRepository balanceRepository)
        {
            _logger = logger;
            _balanceRepository = balanceRepository;
        }

        public async Task<Shared.Entities.Balance> GetByCustomerIdAsync(long customerId)
        {
            var balance = await _balanceRepository.GetByCustomerIdAsync(customerId);
            return balance!;
        }

        public async Task<BalanceDTO> CreateAsync(BalanceDTO balanceDTO)
        {
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<BalanceDTO, Shared.Entities.Balance>(balanceDTO);
                var balanceResponse = await _balanceRepository.CreateAsync(entity);
                balanceDTO.Id = balanceResponse.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return balanceDTO;
        }

        public async Task<BalanceDTO> UpdateAsync(BalanceDTO balanceDTO)
        {
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<BalanceDTO, Shared.Entities.Balance>(balanceDTO);
                await _balanceRepository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return balanceDTO;
        }
    }
}