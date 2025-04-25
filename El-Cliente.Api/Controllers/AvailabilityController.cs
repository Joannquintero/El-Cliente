using El_Cliente.Api.Services.Availability;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityServices _availabilityServices;

        public AvailabilityController(IAvailabilityServices availabilityServices)
        {
            _availabilityServices = availabilityServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomersByBranchIdAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _availabilityServices.GetAvailabilityProductsByBranchIdAsync(pagination);
            return Ok(response);
        }
    }
}