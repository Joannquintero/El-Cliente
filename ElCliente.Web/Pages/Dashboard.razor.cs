using CurrieTechnologies.Razor.SweetAlert2;
using El_Cliente.Shared.DTOs;
using ElCliente.Web.Repository;
using Microsoft.AspNetCore.Components;

namespace ElCliente.Web.Pages
{
    public partial class Dashboard
    {
        private decimal AmountCustomer;

        [Inject] private IRepository _repository { get; set; } = null!;

        private List<RegistrationDTO>? Registrations { get; set; }

        private RegistrationDTO registrationDTO = new();

        private BalanceDTO balanceDTO = new();

        [Parameter]
        public int CustomerId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var balanceResponse = await repository.Get<BalanceDTO>($"api/Balances/GetByCustomerIdAsync?customerId={CustomerId}");
            balanceDTO.Amount = balanceResponse.Response!.Amount;
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            registrationDTO.CustomerId = CustomerId;
            string urlPageRequest = string.Empty;
            urlPageRequest = $"api/Funds/GetRegistrationsByCustomerIdAsync?customerId={registrationDTO.CustomerId}";

            try
            {
                var urlPageResponse = await _repository.Get<List<RegistrationDTO>>(urlPageRequest);
                if (urlPageResponse.HttpResponseMessage.IsSuccessStatusCode && urlPageResponse.Response != null)
                {
                    Registrations = urlPageResponse.Response;
                }
            }
            catch (Exception ex)
            {
                await sweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
            }
        }

        private async Task CancellationsAsync(int id, string identifier, int productId)
        {
            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Deseas cancelar la afiliación a este producto?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "No",
                ConfirmButtonText = "Si"
            });

            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }

            var productResponse = await repository.Get<ProductDTO>($"api/Products/{productId}");
            registrationDTO.Id = id;
            registrationDTO.ProductId = productId;
            registrationDTO.Identifier = identifier;
            var CancellationResponse = await repository.Post<RegistrationDTO, RegistrationDTO>("/api/Funds/CancellationsAsync", registrationDTO);

            balanceDTO.Amount = AmountCustomer + productResponse.Response!.MinimumAmount;
            balanceDTO.CustomerId = registrationDTO.CustomerId;
            var responseHttp = await repository.Put("/api/Balances", balanceDTO);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await LoadAsync();
        }
    }
}