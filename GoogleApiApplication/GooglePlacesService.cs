using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace GoogleApiApplication
{
    public class GooglePlacesService : IGooglePlacesServiceV1
    {
        async Task<GooglePlacesRootObject> IGooglePlacesServiceV1.GetPlacesAutoCompleteResults(string query)
        {
            var url = ($"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={query}&types=geocode&key={GoogleCredentials.ApiKey}");

            var result = GetPlacesResultsAsync(url);

            return await result;
        }

        private async Task<GooglePlacesRootObject> GetPlacesResultsAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return JsonConvert.DeserializeObject<GooglePlacesRootObject>(result);
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}