using CurrieTechnologies.Razor.SweetAlert2;
using El_Cliente.Shared.DTOs;
using ElCliente.Web.Repository;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace ElCliente.Web.Pages.Customers
{
    public partial class CustomersIndex
    {
        [Inject] private IRepository _repository { get; set; } = null!;

        private int currentPage = 1;
        private int totalPages;

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
            string urlPageTotalRequest = string.Empty;

            if (string.IsNullOrEmpty(Filter))
            {
                urlPageRequest = $"api/Customers/GetCustomersByBranchIdAsync?page={page}";
                urlPageTotalRequest = $"api/Customers/totalPages";
            }
            else
            {
                urlPageRequest = $"api/Customers?page={page}&filter={Filter}";
                urlPageTotalRequest = $"api/Customers/totalPages?filter={Filter}";
            }

            try
            {
                var urlPageResponse = await _repository.Get<List<CustomerDTO>>(urlPageRequest);
                if (urlPageResponse.HttpResponseMessage.IsSuccessStatusCode && urlPageResponse.Response != null)
                {
                    Customers = urlPageResponse.Response;
                }

                var urlPageFilterResponse = await _repository.Get<int>(urlPageTotalRequest);
                if (urlPageFilterResponse.HttpResponseMessage.IsSuccessStatusCode)
                {
                    totalPages = urlPageFilterResponse.Response;
                }
            }
            catch (Exception ex)
            {
                await sweetAlertService.FireAsync("Error", ex.Message, SweetAlertIcon.Error);
            }
        }

        private async Task SelectedPageAsync(int page)
        {
            currentPage = page;
            await LoadAsync(page);
        }

        private async Task DeleteAsync(long id)
        {
            var result = await sweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Realmente deseas eliminar el registro?",
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

            var responseHttp = await _repository.Delete($"/api/Customers/{id}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode != HttpStatusCode.NotFound)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                    return;
                }
            }

            await LoadAsync();
        }

        private async Task CleanFilterAsync()
        {
            Filter = string.Empty;
            await ApplyFilterAsync();
        }

        private async Task ApplyFilterAsync()
        {
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }
    }
}