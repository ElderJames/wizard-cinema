using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.QueryServices.DTOs;

namespace Wizard.Cinema.QueryServices
{
    public interface IWizardQueryService
    {
        WizardInfo Get(string account, string passwardMd5);

        WizardInfo Get(long wizardId);

        PagedData<WizardInfo> Search(PagedSearch search);
    }
}
