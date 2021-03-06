﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Infrastructures;
using Newtonsoft.Json;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote
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
            if (keyword.IsNullOrEmpty())
                return Enumerable.Empty<CityResponse.City>();

            return CityLsit.Where(x => x.nm.StartsWith(keyword) || x.py.StartsWith(keyword)).OrderBy(x => x.nm.IndexOf(keyword, StringComparison.Ordinal));
        }

        public CityResponse.City GetById(int id)
        {
            return CityLsit.FirstOrDefault(x => x.id == id);
        }

        public CityResponse.City GetById(long id)
        {
            return CityLsit.FirstOrDefault(x => x.id == id);
        }

        public IEnumerable<CityResponse.City> Find(Func<CityResponse.City, bool> predicate)
        {
            return CityLsit.Where(predicate);
        }
    }
}
