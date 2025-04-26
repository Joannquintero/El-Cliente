using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Customer;
using El_Cliente.Api.Repository.CustomerContact;
using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.CustomerContact
{
    public class CustomerContactServices : ICustomerContactServices
    {
        private readonly ILogger<CustomerContactServices> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerContactRepository _customerContactRepository;

        public CustomerContactServices(
            ILogger<CustomerContactServices> logger,
            ICustomerRepository customerRepository,
            ICustomerContactRepository customerContactRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _customerContactRepository = customerContactRepository;
        }

        public async Task<List<CustomerContactDTO>> GetCustomerContactByCustomerIdAsync(long customerId)
        {
            List<CustomerContactDTO> response = new();
            try
            {
                var customerResponse = await _customerContactRepository.GetByCustomerIdAsync(customerId);
                response = ConvertsExtensions.ConvertToEntity<List<Shared.Entities.CustomerContact>, List<CustomerContactDTO>>(customerResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response!;
        }

        public async Task<CustomerContactDTO> CreateAsync(CustomerContactDTO customerContact)
        {
            try
            {
                var customerResponse = await _customerRepository.GetAsync(customerContact.CustomerId);
                var customerContactObject = new Shared.Entities.CustomerContact
                {
                    Customer = customerResponse,
                    Type = customerContact.Type,
                    Value = customerContact.Value,
                    Notify = customerContact.Notify
                };

                var customersResponse = await _customerContactRepository.CreateAsync(customerContactObject);
                customerContact.Id = customersResponse.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return customerContact!;
        }
    }
}