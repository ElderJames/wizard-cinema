using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote.Spider.Request
{
    public class CinemaRequest : BaseRequest<CinemaResponse>
    {
        public override string Url => $"http://m.maoyan.com/ajax/cinemaList?offset=0&limit=10000&districtId=-1&lineId=-1&hallType=-1&brandId=-1&serviceId=-1&areaId=-1&stationId=-1&item=&updateShowDay=true&cityId={this.CityId}";

        public int CityId { get; set; }
    }
}