namespace El_Cliente.Api.Repository.Registration
{
    public interface IRegistrationRepository
    {
        Task<List<Shared.Entities.Registration>> GetAsync(long customerId);

        Task<Shared.Entities.Registration> GetByIdAsync(long id);

        Task<Shared.Entities.Registration> CreateAsync(Shared.Entities.Registration registration);

        Task<Shared.Entities.Registration> UpdateAsync(Shared.Entities.Registration registration);
    }
}