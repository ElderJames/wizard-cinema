using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Repository.Condition;
using Wizard.Cinema.Remote.Spider;
using Wizard.Cinema.Remote.Spider.Request;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Test
{
    public class RemotetTest : TestBase
    {
        [Fact]
        public void SearchCinemaAndSaveTest()
        {
            var service = ServiceProvider.GetService<CinemaService>();
            var cinemas = service.GetByCityId(new SearchCinemaCondition() { CityId = 10 });
            //1393
            Assert.NotEmpty(cinemas.Records);
            Assert.True(cinemas.TotalCount == 322);
        }

        [Fact]
        public void SearchHallsAndSaveTest()
        {
            var remoteCall = ServiceProvider.GetService<RemoteSpider>();
            var halls = remoteCall.SendAsync(new SeatInfoRequest { SeqNo = "201809280075475" }).Result;

            Assert.NotNull(halls.seatData);
            Assert.NotEmpty(halls.seatData.seat.sections);
        }

        [Fact]
        public void SearchMoviesTest()
        {
            var remoteCall = ServiceProvider.GetService<RemoteSpider>();
            CinemaMoviesResponse movies = remoteCall.SendAsync(new CinemaMoviesRequest() { CinemaId = 13509 }).Result;

            Assert.NotNull(movies.showData);
        }
    }
}
