namespace El_Cliente.Api.Repository.Registration
{
    public interface IRegistrationRepository
    {
        Task<Shared.Entities.Registration> CreateAsync(Shared.Entities.Registration registration);

        Task<Shared.Entities.Registration> UpdateAsync(Shared.Entities.Registration registration);
    }
}