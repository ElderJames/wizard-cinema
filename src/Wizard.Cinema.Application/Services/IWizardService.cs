using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Application.Services.Dto.Response;
using Wizard.Cinema.Infrastructures;

namespace Wizard.Cinema.Application.Services
{
    public interface IWizardService
    {
        ApiResult<WizardResp> GetWizard(string account, string passward);

        ApiResult<WizardResp> GetWizard(long wizardId);

        ApiResult<bool> Register(RegisterWizardReqs request);

        ApiResult<PagedData<WizardResp>> Search(PagedSearch search);
    }
}
