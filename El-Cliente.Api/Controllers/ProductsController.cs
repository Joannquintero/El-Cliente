using El_Cliente.Api.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult> GetByIdAsync(long id)
        {
            var response = await _productServices.GetByIdAsync(id);
            return Ok(response);
        }


        [HttpGet(nameof(GetByBranchIdAsync))]
        public async Task<ActionResult> GetByBranchIdAsync(int branchId)
        {
            var response = await _productServices.GetByBranchIdAsync(branchId);
            return Ok(response);
        }
    }
}