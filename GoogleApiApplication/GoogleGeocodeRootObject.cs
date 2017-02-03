using System.Collections.Generic;

namespace GoogleApiApplication
{
    public class GoogleGeocodeRootObject
    {
        public List<GoogleGeocodeResult> results { get; set; }
        public string status { get; set; }
    }
}