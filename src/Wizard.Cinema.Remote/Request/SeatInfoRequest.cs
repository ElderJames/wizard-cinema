using System;
using System.Collections.Generic;
using System.Text;
using Wizard.Cinema.Remote.Response;

namespace Wizard.Cinema.Remote.Request
{
    public class SeatInfoRequest : BaseRequest<SeatListResponse>
    {
        public override string Url => $"http://m.maoyan.com/ajax/seatingPlan?seqNo={SeqNo}";

        public string SeqNo { get; set; }
    }
}