using El_Cliente.Api.Services.CustomerContact;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactController : ControllerBase
    {
        private readonly ICustomerContactServices _customerContactServices;

        public CustomerContactController(ICustomerContactServices customerContactServices)
        {
            _customerContactServices = customerContactServices;
        }

        [HttpGet(nameof(GetCustomerContactByCustomerIdAsync))]
        public async Task<ActionResult> GetCustomerContactByCustomerIdAsync(long customerId)
        {
            var response = await _customerContactServices.GetCustomerContactByCustomerIdAsync(customerId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CustomerContactDTO customerContactDTO)
        {
            var response = await _customerContactServices.CreateAsync(customerContactDTO);
            return Ok(response);
        }
    }
}