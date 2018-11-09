using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;

namespace Wizard.Cinema.Application.DTOs.Request.Session
{
    public class SearchSelectSeatTaskReqs : PagedSearch
    {
        public long? SessionId { get; set; }
    }
}
