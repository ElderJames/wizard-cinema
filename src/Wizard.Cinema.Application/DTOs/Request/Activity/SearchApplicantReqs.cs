﻿using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;

namespace Wizard.Cinema.Application.DTOs.Request.Activity
{
    public class SearchApplicantReqs : PagedSearch
    {
        public long? ActivityId { get; set; }

        public long? WizardId { get; set; }
    }
}
