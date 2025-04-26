using El_Cliente.Api.Helpers;
using El_Cliente.Api.Repository.Branch;
using El_Cliente.Shared.DTOs;

namespace El_Cliente.Api.Services.Branch
{
    public class BranchServices : IBranchServices
    {
        private readonly ILogger<BranchServices> _logger;
        private readonly IBranchRepository _branchRepository;

        public BranchServices(
            ILogger<BranchServices> logger,
            IBranchRepository branchRepository)
        {
            _logger = logger;
            _branchRepository = branchRepository;
        }

        public async Task<List<BranchDTO>> GetAsync()
        {
            List<BranchDTO>? response = new();
            try
            {
                var branchResponse = await _branchRepository.GetAsync();
                response.AddRange(
                    (from b in branchResponse
                     select new BranchDTO
                     {
                         Id = b.Id,
                         Name = b.Name,
                         City = b.City
                     }).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return response!;
        }
    }
}