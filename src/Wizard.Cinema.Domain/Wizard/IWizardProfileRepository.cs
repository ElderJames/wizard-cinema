using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Wizard
{
    public interface IWizardProfileRepository
    {
        int Insert(WizardProfiles profile);

        void BatchInsert(IEnumerable<WizardProfiles> profiles);

        int Update(WizardProfiles profile);

        WizardProfiles Query(long wizardId);
    }
}
