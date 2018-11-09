using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Wizard.Cinema.Remote.Application;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Remote.Spider;
using Wizard.Cinema.Remote.Spider.Request;
using Infrastructures;
using Wizard.Cinema.Remote.Spider.Response;

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
            if (cinemaId <= 0)
                return Enumerable.Empty<Hall>();

            IEnumerable<Hall> halls = _repository.QueryByCinemaId(cinemaId);
            if (halls.IsNullOrEmpty())
            {
                lock (_locker)
                {
                    halls = _repository.QueryByCinemaId(cinemaId);
                    if (halls.IsNullOrEmpty())
                    {
                        CinemaMoviesResponse movies = _remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = cinemaId }).Result;

                        var shows = movies.showData.movies.SelectMany(x => x.shows.SelectMany(o => o.plist))
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
                            }).Where(x => x != null).Distinct(new SeatListResponseEqualityComparer()).ToList();

                        halls = shows.Select(x =>
                            {
                                string html = String.Empty;
                                try
                                {
                                    html = _remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = x.seatData.show.seqNo }).Result;
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError("获取此次html异常， seqNo:" + x.seatData.show.seqNo, ex);
                                }

                                return new Hall()
                                {
                                    HallId = x.seatData.hall.hallId,
                                    Name = x.seatData.hall.hallName,
                                    CinemaId = x.seatData.cinema.cinemaId,
                                    SeatJson = JsonConvert.SerializeObject(x.seatData.seat),
                                    SeatHtml = html.IsNullOrEmpty()
                                        ? null
                                        : Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1", RegexOptions.Singleline)
                                            .Replace("seat sold", "seat selectable"),
                                    LastUpdateTime = DateTime.Now
                                };
                            }).Where(x => x != null)
                            .ToList();

                        if (halls.Any())
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

        public ApiResult<IEnumerable<Hall>> GetByIds(IEnumerable<long> hallIds)
        {
            return new ApiResult<IEnumerable<Hall>>(ResultStatus.SUCCESS, _repository.QueryByIds(hallIds));
        }
    }
}
