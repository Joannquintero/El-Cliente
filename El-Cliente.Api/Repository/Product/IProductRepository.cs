namespace El_Cliente.Api.Repository.Product
{
    public interface IProductRepository
    {
        Task<Shared.Entities.Product> GetAsync(long id);

        Task<List<Shared.Entities.Product>> GetByBranchIdAsync(long branchId);
    }
}