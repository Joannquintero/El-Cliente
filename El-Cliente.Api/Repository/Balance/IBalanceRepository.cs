namespace El_Cliente.Api.Repository.Balance
{
    public interface IBalanceRepository
    {
        Task<Shared.Entities.Balance> GetByCustomerIdAsync(long id);

        Task<Shared.Entities.Balance> CreateAsync(Shared.Entities.Balance balance);

        Task<Shared.Entities.Balance> UpdateAsync(Shared.Entities.Balance balance);
    }
}