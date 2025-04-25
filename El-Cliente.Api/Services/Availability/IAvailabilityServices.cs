using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Availability
{
    public interface IAvailabilityServices
    {
        Task<Response> GetAvailabilityProductsByBranchIdAsync(PaginationDTO pagination);
    }
}