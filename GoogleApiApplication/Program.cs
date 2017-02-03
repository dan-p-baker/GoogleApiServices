using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleApiApplication
{
    class Program
    {
        private static IGooglePlacesServiceV1 _googlePlacesService;
        private static IGoogleGeocodingServiceV1 _googleGeocodingService;

        static void Main()
        {
            MainAsync();
            Thread.Sleep(5000);
        }
        static async void MainAsync()
        {
            BootstrapApplication();

            Console.WriteLine("Enter a location...");

            var location = Console.ReadLine();            

            Task<GooglePlacesRootObject> placesResultListTask = _googlePlacesService.GetPlacesAutoCompleteResults(location);
            var resultSet = await placesResultListTask.ConfigureAwait(false);

            if (resultSet.predictions.Count > 0)
            {
                var firstResult = resultSet.predictions.FirstOrDefault();

                Console.WriteLine($"The first place found was: {firstResult.description}");
                Console.WriteLine("Searching for coordinates...");

                Task<GoogleGeocodeRootObject> geocodeRootObjectTask = _googleGeocodingService.GetGeocodeFromPlaceId(firstResult.place_id);
                var geocodeRootObject = await geocodeRootObjectTask.ConfigureAwait(false);

                var geocodeResult = geocodeRootObject.results.FirstOrDefault();

                Console.WriteLine($"The coordinates for {firstResult.description} are:");
                Console.WriteLine($"Latitude: {geocodeResult.geometry.location.lat}");
                Console.WriteLine($"Longtitude: {geocodeResult.geometry.location.lng}");

            }
            else if (resultSet.predictions.Count == 0)
                Console.WriteLine("No results were found!");
            else
                Console.WriteLine("Awaiting result...");            
        }

        private static void BootstrapApplication()
        {
            Bootstrap.Start();
            _googlePlacesService = Bootstrap.Container.GetInstance<IGooglePlacesServiceV1>();
            _googleGeocodingService = Bootstrap.Container.GetInstance<IGoogleGeocodingServiceV1>();
        }
    }
}
