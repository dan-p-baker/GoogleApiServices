using System.Threading.Tasks;

namespace GoogleApiApplication
{
    public interface IGoogleGeocodingServiceV1
    {
        Task<GoogleGeocodeRootObject> GetGeocodeFromPlaceId(string placeId);
    }
}
