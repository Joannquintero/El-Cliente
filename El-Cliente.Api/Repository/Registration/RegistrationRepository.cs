using El_Cliente.Api.Data;
using El_Cliente.Api.Helpers;
using El_Cliente.Shared.DTOs;
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

        public async Task<List<Shared.Entities.Registration>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Registrations
                .Where(x => x.CustomerId == pagination.Id)
                .AsQueryable();

            return await queryable
                .OrderByDescending(x => x.Id)
                .Paginate(pagination)
                .ToListAsync();
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