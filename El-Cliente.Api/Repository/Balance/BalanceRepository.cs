using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Balance
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly DataContext _context;

        public BalanceRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<Shared.Entities.Balance> CreateAsync(Shared.Entities.Balance balance)
        {
            _context.Balances.Add(balance);
            await _context.SaveChangesAsync();
            return balance;
        }

        public async Task<Shared.Entities.Balance> UpdateAsync(Shared.Entities.Balance balance)
        {
            _context.Update(balance);
            await _context.SaveChangesAsync();
            return balance;
        }
    }
}