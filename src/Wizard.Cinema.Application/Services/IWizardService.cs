using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.Request.Wizards;
using Wizard.Cinema.Application.Services.Dto.Request;
using Wizard.Cinema.Application.Services.Dto.Request.Wizards;
using Wizard.Cinema.Application.Services.Dto.Response;

namespace Wizard.Cinema.Application.Services
{
    public interface IWizardService
    {
        ApiResult<WizardResp> GetWizard(string account, string passward);

        ApiResult<WizardResp> GetWizard(long wizardId);

        ApiResult<IEnumerable<WizardResp>> GetWizards(long[] wizardId);

        ApiResult<bool> Register(RegisterWizardReqs request);

        ApiResult<bool> CreateWizard(CreateWizardReqs request);

        ApiResult<bool> UpdateWizard(UpdateWizardReqs request);

        ApiResult<PagedData<WizardResp>> Search(SearchWizardReqs search);

        ApiResult<ProfileResp> GetProfile(long wizardId);

        ApiResult<ProfileResp> ChangeProfile(ChangeProfilepReqs request);
    }
}
