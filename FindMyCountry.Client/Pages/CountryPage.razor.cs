using FindMyCountry.shared;
using System.Net.Http.Json;

namespace FindMyCountry.Client.Pages
{
    public partial class CountryPage
    {
        IList<Country> countries;
        protected override async Task OnInitializedAsync()
        {
            countries = await httpClient.GetFromJsonAsync<IList<Country>>("countries");
        }
    }
}
