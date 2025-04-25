using El_Cliente.Api.Services.Funds;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly IFundServices _fundServices;

        public FundsController(IFundServices fundServices)
        {
            _fundServices = fundServices;
        }

        [HttpPost(nameof(OpeningAsync))]
        public async Task<ActionResult> OpeningAsync(RegistrationDTO registrationDTO)
        {
            var response = await _fundServices.OpeningAsync(registrationDTO);
            return Ok(response);
        }

        [HttpPost(nameof(CancellationsAsync))]
        public async Task<ActionResult> CancellationsAsync(RegistrationDTO registrationDTO)
        {
            var response = await _fundServices.CancellationsAsync(registrationDTO);
            return Ok(response);
        }
    }
}