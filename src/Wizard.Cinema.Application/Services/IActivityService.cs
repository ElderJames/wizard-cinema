using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.Request.Activity;
using Wizard.Cinema.Application.DTOs.Response;

namespace Wizard.Cinema.Application.Services
{
    public interface IActivityService
    {
        ApiResult<bool> Create(CreateActivityReqs request);

        ApiResult<bool> Change(UpdateActivityReqs request);

        ApiResult<ActivityResp> GetById(long activityId);

        ApiResult<IEnumerable<ActivityResp>> GetByIds(long[] activityIds);

        ApiResult<PagedData<ActivityResp>> Search(SearchActivityReqs search);

        ApiResult<ApplicantResp> GetApplicant(long applicantId);

        ApiResult<IEnumerable<ApplicantResp>> GetApplicants(string mobile);

        ApiResult<PagedData<ApplicantResp>> SearchApplicant(SearchApplicantReqs request);

        ApiResult<IEnumerable<ApplicantResp>> GetApplicantInActivity(long activityId);

        ApiResult<IEnumerable<ApplicantResp>> List(SearchApplicantReqs request);
    }
}
