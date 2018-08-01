using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Remote.Request
{
    public class FetchSeatHtmlRequest : BaseRequest<string>
    {
        public override string Url => $"http://maoyan.com/xseats/{SeqNo}";

        public string SeqNo { get; set; }

        public override string XPath => "//*[@id=\"app\"]/div[2]/div[1]";
    }
}