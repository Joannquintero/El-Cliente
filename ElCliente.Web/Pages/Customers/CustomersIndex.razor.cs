using CurrieTechnologies.Razor.SweetAlert2;
using El_Cliente.Shared.Entities;
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

        private List<Customer>? Customers { get; set; }

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

            string url1 = string.Empty;
            string url2 = string.Empty;

            if (string.IsNullOrEmpty(Filter))
            {
                url1 = $"api/Customers?page={page}";
                url2 = $"api/Customers/totalPages";
            }
            else
            {
                url1 = $"api/Customers?page={page}&filter={Filter}";
                url2 = $"api/Customers/totalPages?filter={Filter}";
            }

            try
            {
                var responseHppt = await _repository.Get<List<Customer>>(url1);
                var responseHppt2 = await _repository.Get<int>(url2);
                Customers = responseHppt.Response!;
                totalPages = responseHppt2.Response!;
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