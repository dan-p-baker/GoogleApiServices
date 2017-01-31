using System.Collections.Generic;

namespace GoogleApiApplication
{
    public class GooglePlacesResult
    {
        public string Description { get; set; }
        public string Id { get; set; }
    }

    public class GooglePlacesRootObject
    {
        public List<GooglePlacesResult> Predictions { get; set; }
    }
}
