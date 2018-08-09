using System.Linq;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Repository.Condition;

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
            var service = ServiceProvider.GetService<HallService>();
            var halls = service.GetByCinemaId(10401);

            Assert.NotEmpty(halls);
        }
    }
}