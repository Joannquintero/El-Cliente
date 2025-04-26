using El_Cliente.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace El_Cliente.Api.Repository.Registration
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly DataContext _context;

        public RegistrationRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<List<Shared.Entities.Registration>> GetAsync(long customerId)
        {
            var queryable = _context.Registrations
                .Include(r => r.Product)
                .Where(x => x.CustomerId == customerId)
                .AsQueryable();

            return await queryable
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<Shared.Entities.Registration> GetByIdAsync(long id)
        {
            Shared.Entities.Registration? registration = await _context.Registrations
                .FirstOrDefaultAsync(x => x.Id == id);
            return registration!;
        }

        public async Task<Shared.Entities.Registration> CreateAsync(Shared.Entities.Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task<Shared.Entities.Registration> UpdateAsync(Shared.Entities.Registration registration)
        {
            _context.Update(registration);
            await _context.SaveChangesAsync();
            return registration;
        }
    }
}