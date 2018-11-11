using System;
using System.Collections.Generic;

namespace Wizard.Cinema.Application.DTOs.Request.Activity
{
    public class ImportApplicantReqs
    {
        public long ActivityId { get; set; }

        public IEnumerable<ImportData> Data { get; set; }

        public class ImportData
        {
            public string OrderNo { get; set; }

            public string Mobile { get; set; }

            public string RealName { get; set; }

            public string WechatName { get; set; }

            public int Count { get; set; }

            public DateTime CreateTime { get; set; }
        }
    }
}
