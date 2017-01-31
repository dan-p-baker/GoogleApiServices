using System.Threading.Tasks;

namespace GoogleApiApplication
{
    public interface IGooglePlacesServiceV1
    {
        Task<GooglePlacesRootObject> GetPlacesAutoCompleteResults(string query);
    }
}