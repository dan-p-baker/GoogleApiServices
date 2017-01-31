using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleApiApplication
{
    class Program
    {
        private static IGooglePlacesServiceV1 _googlePlacesService;

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
            var resultSet = await _googlePlacesService.GetPlacesAutoCompleteResults(location).ConfigureAwait(false);

            if (resultSet != null)
            {
                var firstResult = resultSet.Predictions.FirstOrDefault();

                Console.WriteLine($"The first place found was: {firstResult.Description}");
            }
            else
                Console.WriteLine("Awaiting result...");
        }

        private static void BootstrapApplication()
        {
            Bootstrap.Start();
            _googlePlacesService = Bootstrap.Container.GetInstance<IGooglePlacesServiceV1>();
        }
    }
}
