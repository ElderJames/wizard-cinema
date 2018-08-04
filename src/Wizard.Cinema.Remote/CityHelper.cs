using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Remote.Response;
using System.IO;

namespace Wizard.Cinema.Admin.Helpers
{
    public class CityHelper
    {
        private static readonly IEnumerable<CityResponse.City> CityLsit;

        static CityHelper()
        {
            if (CityLsit.IsNullOrEmpty())
            {
                string result;
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Wizard.Cinema.Remote.cities.json"))
                using (StreamReader reader = new StreamReader(stream))
                    result = reader.ReadToEnd();

                var json = JsonConvert.DeserializeObject<CityResponse>(result);
                CityLsit = json.letterMap.SelectMany(x => x.Value);
            }
        }

        public IEnumerable<CityResponse.City> Search(string keyword)
        {
            return CityLsit.Where(x => x.nm.Contains(keyword) || x.py.Contains(keyword)).OrderBy(x => x.nm.IndexOf(keyword));
        }
    }
}