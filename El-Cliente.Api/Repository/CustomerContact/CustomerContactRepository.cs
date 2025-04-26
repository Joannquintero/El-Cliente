using El_Cliente.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace El_Cliente.Api.Repository.CustomerContact
{
    public class CustomerContactRepository : ICustomerContactRepository
    {
        private readonly DataContext _context;

        public CustomerContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Shared.Entities.CustomerContact> CreateAsync(Shared.Entities.CustomerContact customerContact)
        {
            _context.CustomerContacts.Add(customerContact);
            await _context.SaveChangesAsync();
            return customerContact;
        }

        public async Task<List<Shared.Entities.CustomerContact>> GetByCustomerIdAsync(long customerId)
        {
            List<Shared.Entities.CustomerContact> customerContacts = await _context.CustomerContacts
                .Where(x => x.Customer.Id == customerId).ToListAsync();
            return customerContacts;
        }
    }
}