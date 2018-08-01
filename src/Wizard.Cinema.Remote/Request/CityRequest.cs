using Wizard.Cinema.Remote.Response;

namespace Wizard.Cinema.Remote.Request
{
    public class CityRequest : BaseRequest<CityResponse>
    {
        public override string Url => "http://maoyan.com/ajax/cities";
    }
}