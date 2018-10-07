using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;

namespace Wizard.Cinema.Application.DTOs.Request.Activity
{
    public class SearchActivityReqs : PagedSearch
    {
        public long? DivisionId { get; set; }
    }
}
