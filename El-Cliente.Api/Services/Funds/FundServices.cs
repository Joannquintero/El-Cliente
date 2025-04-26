using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Balance;
using El_Cliente.Api.Repository.Product;
using El_Cliente.Api.Repository.Registration;
using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Funds
{
    public class FundServices : IFundServices
    {
        private readonly ILogger<FundServices> _logger;
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBalanceRepository _balanceRepository;

        public FundServices(
            ILogger<FundServices> logger,
            IRegistrationRepository registrationRepository,
            IProductRepository productRepository,
            IBalanceRepository balanceRepository)
        {
            _logger = logger;
            _registrationRepository = registrationRepository;
            _productRepository = productRepository;
            _balanceRepository = balanceRepository;
        }

        public async Task<List<RegistrationDTO>> GetRegistrationByCustomerIdAsync(long customerId)
        {
            List<RegistrationDTO> response = new List<RegistrationDTO>();
            try
            {
                var registrationResponse = await _registrationRepository.GetAsync(customerId);
                response.AddRange(
                    (from c in registrationResponse
                     select new RegistrationDTO
                     {
                         Id = c.Id,
                         Product = c.Product,
                         Identifier = c.Identifier,
                         IsActive = c.IsActive
                     }).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<RegistrationDTO> OpeningAsync(RegistrationDTO registrationDTO)
        {
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<RegistrationDTO, Shared.Entities.Registration>(registrationDTO);
                entity.IsActive = true;
                var registrationResponse = await _registrationRepository.CreateAsync(entity);
                registrationDTO.Id = registrationResponse.Id;
                var balance = await _balanceRepository.GetByCustomerIdAsync(registrationDTO.CustomerId);
                var product = _productRepository.GetAsync(registrationDTO.ProductId);
                balance.Amount -= product.Result.MinimumAmount;
                var BalanceResponse = await _balanceRepository.UpdateAsync(balance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return registrationDTO;
        }

        public async Task<RegistrationDTO> CancellationsAsync(RegistrationDTO registrationDTO)
        {
            try
            {
                var registration = await _registrationRepository.GetByIdAsync(registrationDTO.Id);
                registration.IsActive = false;
                var registrationResponse = await _registrationRepository.UpdateAsync(registration);
                var balance = await _balanceRepository.GetByCustomerIdAsync(registrationDTO.CustomerId);
                var product = _productRepository.GetAsync(registrationDTO.ProductId);
                balance.Amount += product.Result.MinimumAmount; ;
                var BalanceResponse = await _balanceRepository.UpdateAsync(balance);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return registrationDTO;
        }
    }
}