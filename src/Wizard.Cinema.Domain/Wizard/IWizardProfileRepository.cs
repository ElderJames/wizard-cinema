using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Wizard
{
    public interface IWizardProfileRepository
    {
        int Insert(WizardProfiles profile);

        int Update(WizardProfiles profile);

        WizardProfiles Query(long wizardId);
    }
}
