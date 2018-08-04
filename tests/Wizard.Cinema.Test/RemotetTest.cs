using System.Linq;
using Wizard.Cinema.Remote.Services;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Wizard.Cinema.Test
{
    public class RemotetTest : TestBase
    {
        [Fact]
        public void SearchCinemaAndSaveTest()
        {
            var service = ServiceProvider.GetService<CinemaService>();
            var cinemas = service.GetByCityId(10);
            //1393
            Assert.NotEmpty(cinemas);
            Assert.True(cinemas.Count() == 322);
        }

        [Fact]
        public void SearchHallsAndSaveTest()
        {
            var service = ServiceProvider.GetService<HallService>();
            var halls = service.GetByCinemaId(10401);

            Assert.NotEmpty(halls);
        }
    }
}