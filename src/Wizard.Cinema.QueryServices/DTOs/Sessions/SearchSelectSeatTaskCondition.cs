using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;

namespace Wizard.Cinema.QueryServices.DTOs.Sessions
{
    public class SearchSelectSeatTaskCondition : PagedSearch
    {
        public long? SessionId { get; set; }
    }
}
