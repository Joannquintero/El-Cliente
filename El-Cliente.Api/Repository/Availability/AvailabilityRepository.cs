using El_Cliente.Api.Data;
using El_Cliente.Api.Helpers;
using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace El_Cliente.Api.Repository.Availability
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly DataContext _context;

        public AvailabilityRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<List<Shared.Entities.Availability>> GetAvailabilityProductsByBranchIdAsync(PaginationDTO pagination)
        {
            var queryable = _context.Availability
                 .Include(x => x.Product)
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Branch.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return await queryable
                .OrderBy(x => x.Branch.Name)
                .Paginate(pagination)
                .ToListAsync();
        }
    }
}