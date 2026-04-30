using FindMyCountry.shared;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System.Net.Http.Json;

namespace FindMyCountry.Client.Pages
{
    public partial class CountryEdit
    {
        [Parameter]
        public int id { get; set; }
        private string? error;
        private Country? country = new Country();
        protected override async Task OnInitializedAsync()
        {
            if(id == 0)
            {
                country = new Country();
            }
            else
            {
                country = await Http.GetFromJsonAsync<Country>("countryedit/" + id);
            }
        }
        private async Task HandleValidSubmit()
        {
            HttpResponseMessage response;
            if(country.CId == 0)
            {
                response = await Http.PostAsJsonAsync("countryedit", country);
            }
            else
            {
                string requestUri = "countries/" + country.CId;
                response = await Http.PutAsJsonAsync(requestUri, country);
            }
            if (response.IsSuccessStatusCode)
            {
                navigationManager.NavigateTo("country");
            }
            else
            {
                error = response.ReasonPhrase;
            }
        }
        private void HandleReset()
        {
            navigationManager.NavigateTo("country");
        }
        private async Task DeleteCountry()
        {
            string requestUri = "countries/" + country.CId;
            var response = await Http.DeleteAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                navigationManager.NavigateTo("country");
            }
            else
            {
                error = response.ReasonPhrase;
            }
        }
    }
}
