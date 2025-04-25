using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Services.Availability
{
    public interface IAvailabilityServices
    {
        Task<Response> GetAvailabilityProductsByBranchIdAsync([FromQuery] PaginationDTO pagination);
    }
}