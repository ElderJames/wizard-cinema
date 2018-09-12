using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Infrastructures;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Wizard.Cinema.Remote;
using Serilog;
using Serilog.Events;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Remote.Application;
using Wizard.Cinema.Remote.Spider;
using Wizard.Cinema.Remote.Spider.Request;

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
            services.AddLogging();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

            services.AddRemote();

            var provider = services.BuildServiceProvider();

            var remoteCall = provider.GetService<RemoteSpider>();
            var cinemaRepository = provider.GetService<ICinemaRepository>();
            var hallRepository = provider.GetService<IHallRepository>();

            var cites = await remoteCall.SendAsync(new CityRequest());

            var totalCityCount = cites.letterMap.SelectMany(x => x.Value).Count();
            foreach (var city in cites.letterMap.SelectMany(x => x.Value))
            {
                Console.WriteLine("城市剩余:" + totalCityCount--);
                try
                {
                    //获取影院
                    var cinemas = await remoteCall.SendAsync(new CinemaRequest() { CityId = city.id });

                    //var splitArr = cinemas.cinemas.Split(20);
                    //splitArr.ForEach(item =>
                    //{
                    //});
                    //cinemas.cinemas.ForEach(o =>
                    //{
                    //    try
                    //    {
                    //        cinemaRepository.Insert(new Remote.Models.Cinema()
                    //        {
                    //            CityId = city.id,
                    //            Address = o.addr,
                    //            CinemaId = o.id,
                    //            Name = o.nm,
                    //            LastUpdateTime = DateTime.Now
                    //        });
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        cinemaRepository.Insert(new Remote.Models.Cinema()
                    //        {
                    //            CityId = city.id,
                    //            Address = o.addr,
                    //            CinemaId = o.id,
                    //            Name = o.nm,
                    //            LastUpdateTime = DateTime.Now
                    //        });
                    //    }
                    //});

                    var cinemaCount = cinemas.cinemas.Length;

                    foreach (var cinema in cinemas.cinemas)
                    {
                        Console.WriteLine("影院剩余：" + cinemaCount--);
                        try
                        {
                            var movies = await remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = cinema.id });

                            var seats = movies.showData.movies.SelectMany(x => x.shows.SelectMany(o => o.plist))
                                .AsParallel().Select(x =>
                                {
                                    try
                                    {
                                        var result = remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = x.seqNo })
                                            .Result;
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

                            seats.Distinct(new SeatListResponseEqualityComparer()).ForEach(x =>
                            {
                                try
                                {
                                    var html = remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = x.seatData.show.seqNo }).Result;

                                    html = Regex.Replace(html, @"\s*(<[^>]+>)\s*", "$1", RegexOptions.Singleline);

                                    hallRepository.Insert(new Hall()
                                    {
                                        HallId = x.seatData.hall.hallId,
                                        Name = x.seatData.hall.hallName,
                                        CinemaId = x.seatData.cinema.cinemaId,
                                        SeatJson = JsonConvert.SerializeObject(x.seatData.seat),
                                        SeatHtml = html.Replace("\r", "").Replace("\n", ""),
                                        LastUpdateTime = DateTime.Now
                                    });
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
