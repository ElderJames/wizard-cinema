using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Wizard.Cinema.Remote;
using Wizard.Cinema.Remote.Request;
using Serilog;
using Serilog.Events;
using Wizard.Cinema.Remote.Repository;
using Wizard.Cinema.Smartsql;

namespace Wizard.Cinema.Collector
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("log.txt", LogEventLevel.Debug)
                .WriteTo.Console(LogEventLevel.Debug)
                .CreateLogger();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            services.AddHttpClient();
            services.AddSingleton<RemoteCall>();
            services.AddSmartSqlStorage(configuration);

            var provider = services.BuildServiceProvider();

            var remoteCall = provider.GetService<RemoteCall>();
            var remoteRepository = provider.GetService<ICinemaRepository>();
            //var cites = await remoteCall.SendAsync(new CityRequest());
            //Console.WriteLine(JsonConvert.SerializeObject(cites));

            var cinemas = await remoteCall.SendAsync(new CinemaRequest() { CityId = 20 });

            remoteRepository.InsertBatch(cinemas.cinemas.Select(item => new Remote.Models.Cinema()
            {
                CityId = 20,
                Address = item.addr,
                CinemaId = item.id,
                Name = item.nm,
                LastUpdateTime = DateTime.Now
            }).ToArray());

            //Console.WriteLine(JsonConvert.SerializeObject(cinemas));

            //var movies = await remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = 184 });
            //Console.WriteLine(JsonConvert.SerializeObject(movies));

            //var seats = await remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = "201808020026945" });
            //Console.WriteLine(JsonConvert.SerializeObject(seats));

            //var seatHtml = await remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = "201808020026945" });
            //Console.WriteLine(seatHtml);

            Console.ReadLine();
        }
    }
}