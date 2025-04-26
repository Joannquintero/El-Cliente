namespace El_Cliente.Api.Repository.Branch
{
    public interface IBranchRepository
    {
        Task<List<Shared.Entities.Branch>> GetAsync();
    }
}