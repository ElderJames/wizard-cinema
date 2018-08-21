using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.QueryServices.DTOs;

namespace Wizard.Cinema.QueryServices
{
    public interface IWizardQueryService
    {
        WizardInfo Query(string account, string passwardMd5);

        WizardInfo Query(long wizardId);

        PagedData<WizardInfo> QueryPaged(PagedSearch search);
    }
}
