using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Remote.Response;

namespace Wizard.Cinema.Admin.Helpers
{
    public class CityHelper
    {
        private static readonly IEnumerable<CityResponse.City> CityLsit;

        static CityHelper()
        {
            if (CityLsit.IsNullOrEmpty())
            {
                var cityText = System.IO.File.ReadAllText("cities.json");
                var json = JsonConvert.DeserializeObject<CityResponse>(cityText);
                CityLsit = json.letterMap.SelectMany(x => x.Value);
            }
        }

        public IEnumerable<CityResponse.City> Search(string keyword)
        {
            return CityLsit.Where(x => x.nm.Contains(keyword) || x.py.Contains(keyword));
        }
    }
}