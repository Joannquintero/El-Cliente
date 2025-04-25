using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
    }
}