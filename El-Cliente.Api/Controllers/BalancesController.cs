using El_Cliente.Api.Services.Balance;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IBalanceServices _balanceServices;

        public BalancesController(IBalanceServices balanceServices)
        {
            _balanceServices = balanceServices;
        }

        [HttpGet(nameof(GetByCustomerIdAsync))]
        public async Task<ActionResult> GetByCustomerIdAsync(long customerId)
        {
            var response = await _balanceServices.GetByCustomerIdAsync(customerId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(BalanceDTO balanceDTO)
        {
            var response = await _balanceServices.CreateAsync(balanceDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(BalanceDTO balanceDTO)
        {
            var response = await _balanceServices.UpdateAsync(balanceDTO);
            return Ok(response);
        }
    }
}