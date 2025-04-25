using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Balance;
using El_Cliente.Api.Repository.Customer;
using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Services.Customer
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBalanceRepository _balanceRepository;

        public CustomerServices(
            ICustomerRepository customerRepository,
            IBalanceRepository balanceRepository)
        {
            _customerRepository = customerRepository;
            _balanceRepository = balanceRepository;
        }

        public async Task<Response> GetCustomersByBranchIdAsync([FromQuery] PaginationDTO pagination)
        {
            Response response = new();
            try
            {
                var customersResponse = await _customerRepository.GetCustomersByBranchIdAsync(pagination);
                List<CustomerDTO> customers = new List<CustomerDTO>();
                customers.AddRange(
                    (from c in customers
                     select new CustomerDTO
                     {
                         Id = c.Id,
                         Name = c.Name,
                         Balances = c.Balances
                     }).ToList());

                response.IsSuccess = true;
                response.Result = customers.Cast<dynamic>().ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response> GetCustomerByIdAsync(long id)
        {
            Response response = new();
            try
            {
                var customerResponse = await _customerRepository.GetAsync(id);
                response.IsSuccess = true;
                response.Result = customerResponse;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response> CreateAsync(CustomerDTO customerDTO)
        {
            Response response = new();
            try
            {
                var entity = ConvertsExtensions.ConvertToEntity<CustomerDTO, Shared.Entities.Customer>(customerDTO);
                var customersResponse = await _customerRepository.CreateAsync(entity);
                var BalanceResponse = await _balanceRepository.CreateAsync(new Shared.Entities.Balance { Customer = customersResponse, Amount = customerDTO.Amount });
                response.IsSuccess = true;
                response.Result = customerDTO;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}