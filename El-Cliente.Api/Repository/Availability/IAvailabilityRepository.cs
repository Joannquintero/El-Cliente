using El_Cliente.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Repository.Availability
{
    public interface IAvailabilityRepository
    {
        Task<List<Shared.Entities.Availability>> GetAvailabilityProductsByBranchIdAsync(PaginationDTO pagination);
    }
}