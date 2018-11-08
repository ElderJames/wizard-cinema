using System.Collections.Generic;

namespace Wizard.Cinema.Domain.Wizard
{
    public interface IWizardRepository
    {
        int Create(Wizards wizard);

        void BatchCreate(IEnumerable<Wizards> wizards);

        int Update(Wizards wizard);

        int UpdatePassword(Wizards wizard);

        int UpdateInfo(Wizards wizard);

        int UpdateMobile(Wizards wizard);

        Wizards Query(long wizardId);

        IEnumerable<Wizards> Query(string[] accounts);

        Wizards Query(string account);
    }
}
