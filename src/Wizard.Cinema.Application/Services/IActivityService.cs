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

        ApiResult<bool> TurnBeginRegistration(long activityId);

        ApiResult<bool> TurnFinishRegistration(long activityId);

        ApiResult<bool> FinishActivity(long activityId);

        ApiResult<bool> BeginActivity(long activityId);

        ApiResult<ActivityResp> GetById(long activityId);

        ApiResult<IEnumerable<ActivityResp>> GetByIds(long[] activityIds);

        ApiResult<PagedData<ActivityResp>> Search(SearchActivityReqs search);

        ApiResult<ApplicantResp> GetApplicant(long applicantId);

        ApiResult<IEnumerable<ApplicantResp>> GetApplicants(string mobile);

        ApiResult<IEnumerable<ApplicantResp>> GetApplicants(long[] wizardIds);

        ApiResult<PagedData<ApplicantResp>> SearchApplicant(SearchApplicantReqs request);

        ApiResult<IEnumerable<ApplicantResp>> GetApplicantInActivity(long activityId);

        ApiResult<IEnumerable<ApplicantResp>> GetApplicantInSession(long sessionId);

        ApiResult<IEnumerable<ApplicantResp>> List(SearchApplicantReqs request);

        /// <summary>
        /// 从微店订单导入
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ApiResult<bool> ImportApplicantsFromWeidian(ImportApplicantReqs request);
    }
}
