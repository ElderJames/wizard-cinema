using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Remote.Request;

namespace Wizard.Cinema.Remote.Services
{
    public class HallService
    {
        private readonly RemoteCall remoteCall;
        private readonly IHallRepository repository;
        private readonly object locker = new object();

        public HallService(RemoteCall remoteCall, IHallRepository repository)
        {
            this.remoteCall = remoteCall;
            this.repository = repository;
        }

        public IEnumerable<Hall> GetByCinemaId(int cinemaId)
        {
            var halls = repository.QueryByCinemaId(cinemaId);
            if (halls.IsNullOrEmpty())
            {
                lock (locker)
                {
                    halls = repository.QueryByCinemaId(cinemaId);
                    if (halls.IsNullOrEmpty())
                    {
                        var movies = remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = cinemaId }).Result;

                        var seats = movies.showData.movies.SelectMany(x => x.shows.SelectMany(o => o.plist))
                            .AsParallel().Select(x =>
                            {
                                try
                                {
                                    var result = remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = x.seqNo }).Result;
                                    if (result?.seatData?.hall == null)
                                    {
                                        Console.WriteLine("结果为null， seqNo:" + x.seqNo);
                                        return null;
                                    }

                                    return result;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    return null;
                                }
                            }).Where(x => x != null)
                            .ToList();

                        halls = seats.Distinct(new SeatListResponseEqualityComparer()).Select(x =>
                        {
                            var html = remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = x.seatData.show.seqNo }).Result;

                            return new Hall()
                            {
                                HallId = x.seatData.hall.hallId,
                                Name = x.seatData.hall.hallName,
                                CinemaId = x.seatData.cinema.cinemaId,
                                SeatJson = JsonConvert.SerializeObject(x.seatData.seat),
                                SeatHtml = html.IsNullOrEmpty() ? null : Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1", RegexOptions.Singleline),
                                LastUpdateTime = DateTime.Now
                            };
                        });

                        repository.InsertBatch(halls);
                    }
                }
            }

            return halls;
        }

        public Hall GetById(int hallId)
        {
            return repository.QueryById(hallId);
        }
    }
}