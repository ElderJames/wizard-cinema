using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Wizard
{
    public interface IWizardRepository
    {
        int Create(Wizards wizard);

        int UpdatePassword(Wizards wizard);

        int UpdateInfo(Wizards wizard);

        int UpdateMobile(Wizards wizard);

        int Query(long wizardId);
    }
}
