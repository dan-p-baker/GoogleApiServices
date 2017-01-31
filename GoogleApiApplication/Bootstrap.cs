using SimpleInjector;

namespace GoogleApiApplication
{
    internal class Bootstrap
    {
        public static Container Container;

        public static void Start()
        {
            Container = new Container();

            Container.Register<IGooglePlacesServiceV1, GooglePlacesService>(Lifestyle.Singleton);
        }


    }
}