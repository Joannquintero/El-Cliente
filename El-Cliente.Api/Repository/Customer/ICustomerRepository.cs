using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Repository.Customer
{
    public interface ICustomerRepository
    {
        Task<List<Shared.Entities.Customer>> GetCustomersByBranchIdAsync(PaginationDTO pagination);

        Task<Shared.Entities.Customer> GetAsync(long id);

        Task<Shared.Entities.Customer> CreateAsync(Shared.Entities.Customer customer);
    }
}