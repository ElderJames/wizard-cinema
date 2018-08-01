using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cinema.Collector
{
    internal class Program
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private static async Task Main(string[] args)
        {
            var json = await HttpClient.GetStringAsync("http://m.maoyan.com/ajax/cinemaList?limit=1&districtId=-1&lineId=-1&hallType=-1&brandId=-1&serviceId=-1&areaId=-1&stationId=-1&item=");
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}