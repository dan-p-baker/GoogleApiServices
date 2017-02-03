using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleApiApplication
{
    public class GoogleGeocodingService : IGoogleGeocodingServiceV1
    {
        async Task<GoogleGeocodeRootObject> IGoogleGeocodingServiceV1.GetGeocodeFromPlaceId(string placeId)
        {
            var url = ($"https://maps.googleapis.com/maps/api/geocode/json?place_id={placeId}&key={GoogleCredentials.ApiKey}");

            var httpClient = new HttpClient();

            Task<string> responseTask = httpClient.GetStringAsync(url);
            var response = await responseTask.ConfigureAwait(false);

            return JsonConvert.DeserializeObject<GoogleGeocodeRootObject>(response);
        }
    }
}