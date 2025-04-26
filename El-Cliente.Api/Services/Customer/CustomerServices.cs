using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Balance;
using El_Cliente.Api.Repository.Customer;
using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Customer
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ILogger<CustomerServices> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBalanceRepository _balanceRepository;

        public CustomerServices(
            ILogger<CustomerServices> logger,
            ICustomerRepository customerRepository,
            IBalanceRepository balanceRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _balanceRepository = balanceRepository;
        }

        public async Task<List<CustomerDTO>> GetCustomersByBranchIdAsync(PaginationDTO pagination)
        {
            List<CustomerDTO> response = new List<CustomerDTO>();
            try
            {
                var customersResponse = await _customerRepository.GetCustomersByBranchIdAsync(pagination);
                response.AddRange(
                    (from c in customersResponse
                     select new CustomerDTO
                     {
                         Id = c.Id,
                         Name = c.Name,
                         Surnames = c.Surnames,
                         Balances = c.Balances
                     }).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response;
        }

        public async Task<double> GetPagesAsync(PaginationDTO pagination)
        {
            double totalPages = 0;
            try
            {
                return await _customerRepository.GetPagesdAsync(pagination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return totalPages;
            }
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(long id)
        {
            CustomerDTO? response = null;
            try
            {
                var customerResponse = await _customerRepository.GetAsync(id);
                response = ConvertsExtensions.ConvertToEntity<Shared.Entities.Customer, CustomerDTO>(customerResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response!;
        }

        public async Task<CustomerDTO> CreateAsync(CustomerDTO customerDTO)
        {
            try
            {
                var entityCustomer = ConvertsExtensions.ConvertToEntity<CustomerDTO, Shared.Entities.Customer>(customerDTO);
                var customersResponse = await _customerRepository.CreateAsync(entityCustomer);
                customerDTO.Id = customersResponse.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return customerDTO;
        }
    }
}