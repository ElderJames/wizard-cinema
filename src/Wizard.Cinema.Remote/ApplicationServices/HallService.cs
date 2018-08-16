using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.Remote.Application;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Remote.Spider;
using Wizard.Cinema.Remote.Spider.Request;

namespace Wizard.Cinema.Remote.ApplicationServices
{
    public class HallService
    {
        private readonly RemoteSpider _remoteCall;
        private readonly IHallRepository _repository;
        private readonly ILogger<HallService> _logger;
        private readonly object _locker = new object();

        public HallService(RemoteSpider remoteCall, IHallRepository repository, ILogger<HallService> logger)
        {
            this._remoteCall = remoteCall;
            this._repository = repository;
            this._logger = logger;
        }

        public IEnumerable<Hall> GetByCinemaId(int cinemaId)
        {
            var halls = _repository.QueryByCinemaId(cinemaId);
            if (halls.IsNullOrEmpty())
            {
                lock (_locker)
                {
                    halls = _repository.QueryByCinemaId(cinemaId);
                    if (halls.IsNullOrEmpty())
                    {
                        var movies = _remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = cinemaId }).Result;

                        var seats = movies.showData.movies.SelectMany(x => x.shows.SelectMany(o => o.plist))
                            .AsParallel().Select(x =>
                            {
                                try
                                {
                                    var result = _remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = x.seqNo }).Result;
                                    if (result?.seatData?.hall == null)
                                    {
                                        _logger.LogError("结果为null， seqNo:" + x.seqNo);
                                        return null;
                                    }

                                    return result;
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError("获取场次异常， seqNo:" + x.seqNo, ex);
                                    return null;
                                }
                            }).Where(x => x != null)
                            .ToList();

                        halls = seats.Distinct(new SeatListResponseEqualityComparer()).Select(x =>
                        {
                            var html = _remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = x.seatData.show.seqNo }).Result;

                            return new Hall()
                            {
                                HallId = x.seatData.hall.hallId,
                                Name = x.seatData.hall.hallName,
                                CinemaId = x.seatData.cinema.cinemaId,
                                SeatJson = JsonConvert.SerializeObject(x.seatData.seat),
                                SeatHtml = html.IsNullOrEmpty() ? null : Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1", RegexOptions.Singleline).Replace("seat sold", "seat selectable"),
                                LastUpdateTime = DateTime.Now
                            };
                        }).ToList();

                        _repository.InsertBatch(halls);
                    }
                }
            }

            return halls;
        }

        public Hall GetById(int hallId)
        {
            return _repository.QueryById(hallId);
        }
    }
}