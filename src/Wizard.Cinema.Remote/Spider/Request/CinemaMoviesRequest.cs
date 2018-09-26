using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote.Spider.Request
{
    public class CinemaMoviesRequest : BaseRequest<CinemaMoviesResponse>
    {
        public override string Url => $"http://m.maoyan.com/ajax/cinemaDetail?cinemaId={CinemaId}";

        public int CinemaId { get; set; }
    }
}
