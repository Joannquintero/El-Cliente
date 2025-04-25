using El_Cliente.Api.Data;

namespace El_Cliente.Api.Repository.Balance
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly DataContext _dataContext;

        public BalanceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Shared.Entities.Balance> CreateAsync(Shared.Entities.Balance balance)
        {
            _dataContext.Balances.Add(balance);
            await _dataContext.SaveChangesAsync();
            return balance;
        }

        public async Task<Shared.Entities.Balance> UpdateAsync(Shared.Entities.Balance balance)
        {
            _dataContext.Update(balance);
            await _dataContext.SaveChangesAsync();
            return balance;
        }
    }
}