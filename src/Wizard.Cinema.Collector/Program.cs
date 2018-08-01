using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wizard.Cinema.Remote;
using Wizard.Cinema.Remote.Request;

namespace Wizard.Cinema.Collector
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddHttpClient();
            services.AddSingleton<RemoteCall>();

            var provider = services.BuildServiceProvider();

            var remoteCall = provider.GetService<RemoteCall>();

            //var cites = await remoteCall.SendAsync(new CityRequest());
            //Console.WriteLine(JsonConvert.SerializeObject(cites));

            //var cinemas = await remoteCall.SendAsync(new CinemaRequest() { CityId = 20 });
            //Console.WriteLine(JsonConvert.SerializeObject(cinemas));

            //var movies = await remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = 184 });
            //Console.WriteLine(JsonConvert.SerializeObject(movies));

            //var seats = await remoteCall.SendAsync(new SeatInfoRequest() { SeqNo = "201808020026945" });
            //Console.WriteLine(JsonConvert.SerializeObject(seats));

            var seatHtml = await remoteCall.FeatchHtmlAsync(new FetchSeatHtmlRequest() { SeqNo = "201808020026945" });
            Console.WriteLine(seatHtml);

            Console.ReadLine();
        }
    }
}