using System;
using System.Linq;
using Infrastructures;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Remote.Repository.Condition;
using Wizard.Cinema.Remote.Spider;
using Wizard.Cinema.Remote.Spider.Request;

namespace Wizard.Cinema.Remote.ApplicationServices
{
    public class CinemaService
    {
        private readonly RemoteSpider _remoteCall;
        private readonly ICinemaRepository _cinemaRepository;
        private readonly object _locker = new object();

        public CinemaService(RemoteSpider remoteCall, ICinemaRepository cinemaRepository)
        {
            this._remoteCall = remoteCall;
            this._cinemaRepository = cinemaRepository;
        }

        public PagedData<Models.Cinema> GetByCityId(SearchCinemaCondition condition)
        {
            if (condition.CityId <= 0)
                return new PagedData<Models.Cinema>();

            if (condition.PageNow == 1)
            {
                var cinemas = Enumerable.Empty<Models.Cinema>();
                var count = _cinemaRepository.QueryCount(condition.CityId);

                if (count > 0)
                    cinemas = _cinemaRepository.Query(condition);
                else
                {
                    lock (_locker)
                    {
                        count = _cinemaRepository.QueryCount(condition.CityId);
                        if (count > 0)
                            cinemas = _cinemaRepository.Query(condition);
                        else
                        {
                            var data = _remoteCall.SendAsync(new CinemaRequest { CityId = condition.CityId }).Result;
                            cinemas = data.cinemas.Select(x => new Models.Cinema()
                            {
                                CityId = condition.CityId,
                                CinemaId = x.id,
                                Name = x.nm,
                                Address = x.addr,
                                LastUpdateTime = DateTime.Now
                            });

                            var splitArr = cinemas.Split(20);
                            foreach (var arr in splitArr)
                                _cinemaRepository.InsertBatch(arr);
                            count = cinemas.Count();
                        }
                    }
                }
                return new PagedData<Models.Cinema>() { PageNow = condition.PageNow, PageSize = condition.PageSize, TotalCount = count, Records = cinemas };
            }
            return _cinemaRepository.QueryPaged(condition);
        }
    }
}
