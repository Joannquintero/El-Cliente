using CurrieTechnologies.Razor.SweetAlert2;
using El_Cliente.Shared.DTOs;
using ElCliente.Web.Repository;
using Microsoft.AspNetCore.Components;

namespace ElCliente.Web.Pages.Customers
{
    public partial class CustomersIndex
    {
        [Inject] private IRepository _repository { get; set; } = null!;

        private List<CustomerDTO>? Customers { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public string Page { get; set; } = string.Empty;

        [Parameter]
        [SupplyParameterFromQuery]
        public string Filter { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync(int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = Convert.ToInt32(Page);
            }

            string urlPageRequest = string.Empty;
            urlPageRequest = $"api/Customers/GetCustomersByBranchIdAsync?page={page}";

            try
            {
                var urlPageResponse = await _repository.Get<List<CustomerDTO>>(urlPageRequest);
                if (urlPageResponse.HttpResponseMessage.IsSuccessStatusCode && urlPageResponse.Response != null)
                {
                    Customers = urlPageResponse.Response;
                }
            }
            catch (Exception ex)
            {
                await sweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
            }
        }
    }
}