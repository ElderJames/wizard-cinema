using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Application.DTOs.Request.Wizards
{
    public class UpdateWizardReqs
    {
        public long WizardId { get; set; }

        public string Account { get; set; }

        public string Passward { get; set; }

        public long DivisionId { get; set; }
    }
}
