using El_Cliente.Api.Repository.Availability;
using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace El_Cliente.Api.Services.Availability
{
    public class AvailabilityServices : IAvailabilityServices
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public AvailabilityServices(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<Response> GetAvailabilityProductsByBranchIdAsync([FromQuery] PaginationDTO pagination)
        {
            Response response = new();
            try
            {
                var availabilityResponse = await _availabilityRepository.GetAvailabilityProductsByBranchIdAsync(pagination);
                List<Shared.Entities.Availability> availability = new List<Shared.Entities.Availability>();
                availability.AddRange(
                    (from c in availability
                     select new Shared.Entities.Availability
                     {
                         Id = c.Id,
                         Product = c.Product
                     }).ToList());

                response.IsSuccess = true;
                response.Result = availability.Cast<dynamic>().ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
