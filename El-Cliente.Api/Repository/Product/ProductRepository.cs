using El_Cliente.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace El_Cliente.Api.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<Shared.Entities.Product> GetAsync(long id)
        {
            Shared.Entities.Product? product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == id);
            return product!;
        }

        public async Task<List<Shared.Entities.Product>> GetByBranchIdAsync(long branchId)
        {
            List<Shared.Entities.Product> response = new();
            List<Shared.Entities.Availability> availability = await _context.Availability
                  .Where(x => x.BranchId == branchId)
                  .Include(x => x.Product)
                  .ToListAsync();

            foreach (var ava in availability)
            {
                response.Add(ava.Product);
            }
            return response!;
        }
    }
}