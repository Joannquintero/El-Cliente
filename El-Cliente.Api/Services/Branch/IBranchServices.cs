using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Branch
{
    public interface IBranchServices
    {
        Task<List<BranchDTO>> GetAsync();
    }
}