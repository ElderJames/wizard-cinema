using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Ministry
{
    /// <summary>
    /// 踪丝
    /// </summary>
    public class Traces
    {
        public long TraceId { get; private set; }

        public long WizardId { get; private set; }

        public string LoginIp { get; private set; }

        public DateTime LoginTime { get; private set; }
    }
}
