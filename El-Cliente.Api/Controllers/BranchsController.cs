using El_Cliente.Api.Services.Branch;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly IBranchServices _branchServices;

        public BranchsController(IBranchServices branchServices)
        {
            _branchServices = branchServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var response = await _branchServices.GetAsync();
            return Ok(response);
        }
    }
}