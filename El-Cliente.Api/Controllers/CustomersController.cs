using El_Cliente.Api.Services.Customer;
using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("/api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomersByBranchIdAsync([FromQuery] PaginationDTO pagination)
        {
            Response response = await _customerServices.GetCustomersByBranchIdAsync(pagination);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CustomerDTO customerDTO)
        {
            Response response = await _customerServices.CreateAsync(customerDTO);
            return Ok(response);
        }
    }
}