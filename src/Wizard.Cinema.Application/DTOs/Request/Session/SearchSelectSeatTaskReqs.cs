using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Request.Session
{
    public class SearchSelectSeatTaskReqs : PagedSearch
    {
        public long? SessionId { get; set; }

        public SelectTaskStatus? Status { get; set; }
    }
}
