using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Registration
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly DataContext _context;

        public RegistrationRepository(DataContext dataContext)
        {
            _context = dataContext;
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