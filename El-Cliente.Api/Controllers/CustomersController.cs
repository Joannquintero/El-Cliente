using El_Cliente.Api.Services.Customer;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
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
            var response = await _customerServices.GetCustomersByBranchIdAsync(pagination);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CustomerDTO customerDTO)
        {
            var response = await _customerServices.CreateAsync(customerDTO);
            return Ok(response);
        }
    }
}