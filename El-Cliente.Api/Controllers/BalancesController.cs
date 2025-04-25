using El_Cliente.Api.Services.Balance;
using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;
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
        public async Task<Response> CreateAsync(BalanceDTO balanceDTO)
        {
            Response response = new();
            try
            {
                var BalanceResponse = await _balanceServices.CreateAsync(balanceDTO);
                response.IsSuccess = true;
                response.Result = BalanceResponse;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpPut]
        public async Task<Response> UpdateAsync(BalanceDTO balanceDTO)
        {
            Response response = new();
            try
            {
                var customersResponse = await _balanceServices.UpdateAsync(balanceDTO);
                response.IsSuccess = true;
                response.Result = customersResponse;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}