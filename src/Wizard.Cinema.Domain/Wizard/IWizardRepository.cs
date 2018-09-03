using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Wizard
{
    public interface IWizardRepository
    {
        int Create(Wizards wizard);

        int Update(Wizards wizard);

        int UpdatePassword(Wizards wizard);

        int UpdateInfo(Wizards wizard);

        int UpdateMobile(Wizards wizard);

        Wizards Query(long wizardId);

        Wizards Query(string account);
    }
}
