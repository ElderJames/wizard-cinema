using System;
using System.Collections.Generic;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote.ApplicationServices
{
    public class CityService
    {
        private readonly Lazy<CityHelper> _cityhelper = new Lazy<CityHelper>();

        public IEnumerable<CityResponse.City> Search(string keyword)
        {
            return _cityhelper.Value.Search(keyword);
        }

        public CityResponse.City GetById(int id)
        {
            return _cityhelper.Value.GetById(id);
        }
    }
}
