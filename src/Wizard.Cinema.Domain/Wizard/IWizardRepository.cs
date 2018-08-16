using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Wizard
{
    public interface IWizardRepository
    {
        int Create(Wizards wizard);

        int ChangePassword(Wizards wizard);

        int ChangeInfo(Wizards wizard);

        int ChangeMobile(Wizards wizard);

        int Get(long wizardId);
    }
}