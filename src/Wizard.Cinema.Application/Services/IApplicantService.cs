using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.Request.Activity;
using Wizard.Cinema.Application.DTOs.Response;

namespace Wizard.Cinema.Application.Services
{
    public interface IApplicantService
    {
        ApiResult<IEnumerable<ApplicantResp>> List(SearchApplicantReqs request);

        ApiResult<IEnumerable<ApplicantResp>> GetApplicantInActivity(long activityId);
    }
}
