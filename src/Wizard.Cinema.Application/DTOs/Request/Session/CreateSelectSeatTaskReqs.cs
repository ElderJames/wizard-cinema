using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Application.DTOs.Request.Session
{
    public class CreateSelectSeatTaskReqs
    {
        public long SessionId { get; set; }

        public long ActivityId { get; set; }
    }
}
