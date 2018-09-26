﻿using System.Collections.Generic;
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

        ApiResult<PagedData<ActivityResp>> Search(PagedSearch search);

        ApiResult<ApplicantResp> GetApplicant(long applicantId);

        ApiResult<PagedData<ApplicantResp>> SearchApplicant(PagedSearch search);
    }
}