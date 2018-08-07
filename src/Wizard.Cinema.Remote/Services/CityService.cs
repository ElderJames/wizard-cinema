using System;
using System.Collections.Generic;
using Wizard.Cinema.Remote.Response;

namespace Wizard.Cinema.Remote.Services
{
    public class CityService
    {
        private readonly Lazy<CityHelper> _cityhelper = new Lazy<CityHelper>();

        public IEnumerable<CityResponse.City> Search(string keyword)
        {
            return _cityhelper.Value.Search(keyword);
        }
    }
}