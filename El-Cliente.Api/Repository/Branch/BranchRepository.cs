using El_Cliente.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace El_Cliente.Api.Repository.Branch
{
    public class BranchRepository : IBranchRepository
    {
        private readonly DataContext _context;

        public BranchRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Shared.Entities.Branch>> GetAsync()
        {
            var branchs = await _context.Branchs.ToListAsync();
            return branchs!;
        }
    }
}