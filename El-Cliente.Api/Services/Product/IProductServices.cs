using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Product
{
    public interface IProductServices
    {
        Task<List<ProductDTO>> GetByBranchIdAsync(long branchId);

        Task<ProductDTO> GetByIdAsync(long id);
    }
}