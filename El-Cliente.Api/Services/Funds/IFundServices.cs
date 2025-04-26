using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Funds
{
    public interface IFundServices
    {
        Task<List<RegistrationDTO>> GetRegistrationByCustomerIdAsync(long customerId);

        Task<RegistrationDTO> OpeningAsync(RegistrationDTO registrationDTO);

        Task<RegistrationDTO> CancellationsAsync(RegistrationDTO registrationDTO);
    }
}