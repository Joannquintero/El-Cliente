using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}