using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs;
using Wizard.Cinema.QueryServices.DTOs.Wizards;

namespace Wizard.Cinema.QueryServices
{
    public interface IWizardQueryService
    {
        WizardInfo Query(string account);

        WizardInfo QueryByEmail(string email);

        WizardInfo Query(string account, string passwardMd5);

        WizardInfo Query(long wizardId);

        PagedData<WizardInfo> QueryPaged(WizardSearch search);
    }
}
