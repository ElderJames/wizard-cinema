using System;
using System.Collections.Generic;
using Wizard.Cinema.Admin.Helpers;
using Wizard.Cinema.Remote.Response;

namespace Wizard.Cinema.Remote.Services
{
    public class CityService
    {
        private readonly Lazy<CityHelper> cityhelper = new Lazy<CityHelper>();

        public IEnumerable<CityResponse.City> Search(string keyword)
        {
            return cityhelper.Value.Search(keyword);
        }
    }
}