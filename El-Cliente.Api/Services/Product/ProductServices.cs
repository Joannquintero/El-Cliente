using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Product;
using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Product
{
    public class ProductServices : IProductServices
    {
        private readonly ILogger<ProductServices> _logger;
        private readonly IProductRepository _productRepository;

        public ProductServices(
            ILogger<ProductServices> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> GetByIdAsync(long id)
        {
            ProductDTO? response = null;
            try
            {
                var productResponse = await _productRepository.GetAsync(id);
                response = ConvertsExtensions.ConvertToEntity<Shared.Entities.Product, ProductDTO>(productResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response!;
        }

        public async Task<List<ProductDTO>> GetByBranchIdAsync(long branchId)
        {
            List<ProductDTO> response = new();
            try
            {
                var productResponse = await _productRepository.GetByBranchIdAsync(branchId);
                response.AddRange(
                    (from b in productResponse
                     select new ProductDTO
                     {
                         Id = b.Id,
                         Name = b.Name,
                         Category = b.Category,
                         MinimumAmount = b.MinimumAmount
                     }).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response!;
        }
    }
}