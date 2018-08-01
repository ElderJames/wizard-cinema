using System.Collections.Generic;

namespace Wizard.Cinema.Remote.Response
{
    public class CityResponse
    {
        public Dictionary<string, City[]> letterMap { get; set; }

        public class City
        {
            public int id { get; set; }
            public string nm { get; set; }
            public string py { get; set; }
        }
    }
}