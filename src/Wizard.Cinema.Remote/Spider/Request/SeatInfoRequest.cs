using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote.Spider.Request
{
    public class SeatInfoRequest : BaseRequest<SeatListResponse>
    {
        public override string Url => $"http://m.maoyan.com/ajax/seatingPlan?seqNo={SeqNo}";

        public string SeqNo { get; set; }
    }
}