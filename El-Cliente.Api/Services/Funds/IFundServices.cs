using El_Cliente.Shared.DTOs;
using El_Cliente.Shared.Responses;

namespace El_Cliente.Api.Services.Funds
{
    public interface IFundServices
    {
        Task<Response> OpeningAsync(RegistrationDTO registrationDTO);

        Task<Response> CancellationsAsync(RegistrationDTO registrationDTO);
    }
}