using System.Collections.Generic;
using System.Linq;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Remote.Request;

namespace Wizard.Cinema.Remote.Services
{
    public class CinemaService
    {
        private readonly RemoteCall remoteCall;
        private readonly ICinemaRepository cinemaRepository;
        private readonly object locker = new object();

        public CinemaService(RemoteCall remoteCall, ICinemaRepository cinemaRepository)
        {
            this.remoteCall = remoteCall;
            this.cinemaRepository = cinemaRepository;
        }

        public IEnumerable<Models.Cinema> GetByCityId(int cityId)
        {
            var cinemas = cinemaRepository.Query(cityId);
            if (cinemas.IsNullOrEmpty())
            {
                lock (locker)
                {
                    cinemas = cinemaRepository.Query(cityId);
                    if (cinemas.IsNullOrEmpty())
                    {
                        var data = remoteCall.SendAsync(new CinemaRequest { CityId = cityId }).Result;
                        cinemas = data.cinemas.Select(x => new Models.Cinema()
                        {
                            CityId = cityId,
                            CinemaId = x.id,
                            Name = x.nm,
                            Address = x.addr,
                        });

                        var splitArr = cinemas.Split(20);
                        foreach (var arr in splitArr)
                            cinemaRepository.InsertBatch(arr);
                    }
                }
            }

            return cinemas;
        }
    }
}