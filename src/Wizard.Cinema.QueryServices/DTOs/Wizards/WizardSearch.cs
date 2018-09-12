using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;

namespace Wizard.Cinema.QueryServices.DTOs.Wizards
{
    public class WizardSearch : PagedSearch
    {
        public bool IsAdmin { get; set; }
    }
}
