using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Wizard.Cinema.Remote;
using Wizard.Cinema.Remote.Request;
using Serilog;
using Serilog.Events;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Remote.Response;
using Wizard.Cinema.Smartsql;

namespace Wizard.Cinema.Collector
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            var configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("log.txt", LogEventLevel.Debug)
                .WriteTo.Console(LogEventLevel.Debug)
                .CreateLogger();

            var services = new ServiceCollection();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(Log.Logger));

            services.AddHttpClient();
            services.AddSingleton<RemoteCall>();
            services.AddSmartSqlStorage(configuration);

            var provider = services.BuildServiceProvider();

            var remoteCall = provider.GetService<RemoteCall>();
            var cinemaRepository = provider.GetService<ICinemaRepository>();
            var hallRepository = provider.GetService<IHallRepository>();
            //var cites = await remoteCall.SendAsync(new CityRequest());
            //Console.WriteLine(JsonConvert.SerializeObject(cites));

            //var cinemas = await remoteCall.SendAsync(new CinemaRequest() { CityId = 10 });

            //cinemaRepository.InsertBatch(cinemas.cinemas.Take(2).Select(item => new Remote.Models.Cinema()
            //{
            //    CityId = 10,
            //    Address = item.addr,
            //    CinemaId = item.id,
            //    Name = item.nm,
            //    LastUpdateTime = DateTime.Now
            //}).ToArray());

            //Console.WriteLine(JsonConvert.SerializeObject(cinemas));

            var movies = await remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = 184 });

            //foreach (var item in movies.showData.movies.SelectMany(x => x.shows.SelectMany(o => o.plist)))
            //{
            //    var seats = await remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = item.seqNo });
            //}

            var seats = movies.showData.movies.SelectMany(x => x.shows.SelectMany(o => o.plist)).AsParallel().Select(
                x =>
                {
                    var hall = remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = x.seqNo }).Result;
                    var html = remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = x.seqNo }).Result;
                    return (hall, html);
                }).ToList();

            try
            {
                var arr = seats.Distinct(new SeatListResponseEqualityComparer()).Select(x => new Hall()
                {
                    HallId = x.Item1.seatData.hall.hallId,
                    Name = x.Item1.seatData.hall.hallName,
                    CinemaId = x.Item1.seatData.cinema.cinemaId,
                    SeatJson = JsonConvert.SerializeObject(x.Item1.seatData.seat),
                    SeatHtml = x.Item2,
                    LastUpdateTime = DateTime.Now
                }).ToArray();
                hallRepository.InsertBatch(arr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Console.WriteLine(JsonConvert.SerializeObject(movies));

            //var seats = await remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = "201808020026945" });
            //Console.WriteLine(JsonConvert.SerializeObject(seats));

            //var seatHtml = await remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = "201808020026945" });
            //Console.WriteLine(seatHtml);

            Console.ReadLine();
        }

        public class SeatListResponseEqualityComparer : IEqualityComparer<(SeatListResponse, string)>
        {
            public bool Equals((SeatListResponse, string) x, (SeatListResponse, string) y)
            {
                return x.Item1.seatData.hall.hallId == y.Item1.seatData.hall.hallId;
            }

            public int GetHashCode((SeatListResponse, string) obj)
            {
                return obj.Item1.seatData.hall.hallId;
            }
        }
    }
}