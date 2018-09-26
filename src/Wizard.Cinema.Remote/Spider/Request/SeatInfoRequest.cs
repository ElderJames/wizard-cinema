using System.Net.Http;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote.Spider.Request
{
    public class SeatInfoRequest : BaseRequest<SeatListResponse>
    {
        public override string Url => $"http://m.maoyan.com/ajax/seatingPlan?timestamp=1537985301598";

        public string SeqNo { get; set; }

        public override HttpMethod Method => HttpMethod.Post;

        public override string PostData => $"seqNo={SeqNo}";
    }
}
