using El_Cliente.Api.Services.Customer;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> logger;
        private readonly ICustomerServices _customerServices;

        public CustomersController(
            ILogger<CustomersController> logger,
            ICustomerServices customerServices)
        {
            this.logger = logger;
            _customerServices = customerServices;
        }

        [HttpGet(nameof(GetCustomersByBranchIdAsync))]
        public async Task<ActionResult> GetCustomersByBranchIdAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _customerServices.GetCustomersByBranchIdAsync(pagination);
            return Ok(response);
        }

        [HttpGet("TotalPages")]
        [AllowAnonymous]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var response = await _customerServices.GetPagesAsync(pagination);
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult> GetCustomerByIdAsync(long id)
        {
            var response = await _customerServices.GetCustomerByIdAsync(id);
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