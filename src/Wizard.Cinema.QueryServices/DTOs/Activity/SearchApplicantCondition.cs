using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;

namespace Wizard.Cinema.QueryServices.DTOs.Activity
{
    public class SearchApplicantCondition : PagedSearch
    {
        public long? ActivityId { get; set; }

        public long? WizardId { get; set; }
    }
}
