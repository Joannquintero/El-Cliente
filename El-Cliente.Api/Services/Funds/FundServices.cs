using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Balance;
using El_Cliente.Api.Repository.Registration;
using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Funds
{
    public class FundServices : IFundServices
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IBalanceRepository _balanceRepository;

        public FundServices(
            IRegistrationRepository registrationRepository,
            IBalanceRepository balanceRepository)
        {
            _registrationRepository = registrationRepository;
            _balanceRepository = balanceRepository;
        }

        public async Task<Response> GetRegistrationByCustomerIdAsync(PaginationDTO pagination)
        {
            Response response = new();
            try
            {
                var registrationResponse = await _registrationRepository.GetAsync(pagination);
                List<Shared.Entities.Registration> registration = new List<Shared.Entities.Registration>();
                registration.AddRange(
                    (from c in registrationResponse
                     select new Shared.Entities.Registration
                     {
                         Id = c.Id,
                         Product = c.Product,
                         Identifier = c.Identifier,
                         IsActive = c.IsActive
                     }).ToList());

                response.IsSuccess = true;
                response.Result = registration.Cast<dynamic>().ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response> OpeningAsync(RegistrationDTO registrationDTO)
        {
            Response response = new();
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<RegistrationDTO, Shared.Entities.Registration>(registrationDTO);
                var customersResponse = await _registrationRepository.CreateAsync(entity);
                //var BalanceResponse = await _balanceRepository.UpdateAsync(new Shared.Entities.Balance { Customer = customersResponse, Amount = customerDTO.Amount });
                // transaccion
                response.IsSuccess = true;
                response.Result = customersResponse;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response> CancellationsAsync(RegistrationDTO registrationDTO)
        {
            Response response = new();
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<RegistrationDTO, Shared.Entities.Registration>(registrationDTO);
                var customersResponse = await _registrationRepository.UpdateAsync(entity);
                //var BalanceResponse = await _balanceRepository.CreateAsync(new Shared.Entities.Balance { Customer = customersResponse, Amount = customerDTO.Amount });
                response.IsSuccess = true;
                response.Result = registrationDTO;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}