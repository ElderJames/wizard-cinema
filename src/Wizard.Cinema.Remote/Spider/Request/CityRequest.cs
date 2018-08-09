using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote.Spider.Request
{
    public class CityRequest : BaseRequest<CityResponse>
    {
        public override string Url => "http://maoyan.com/ajax/cities";
    }
}