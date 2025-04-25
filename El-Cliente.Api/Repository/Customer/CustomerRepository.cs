using El_Cliente.Api.Data;
using El_Cliente.Api.Helpers;
using El_Cliente.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace El_Cliente.Api.Repository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Shared.Entities.Customer>> GetCustomersByBranchIdAsync(PaginationDTO pagination)
        {
            var queryable = _context.Customers
                 .Include(x => x.Balances)
                 .Include(x => x.Registrations)
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync();
        }

        public async Task<double> GetPagesdAsync(PaginationDTO pagination)
        {
            var queryable = _context.Customers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            return Math.Ceiling(count / pagination.RecordsNumber);
        }

        public async Task<Shared.Entities.Customer> GetAsync(long id)
        {
            Shared.Entities.Customer? customer = await _context.Customers
                .FirstOrDefaultAsync(x => x.Id == id);
            return customer!;
        }

        public async Task<Shared.Entities.Customer> CreateAsync(Shared.Entities.Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}