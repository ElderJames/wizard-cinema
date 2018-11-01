using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Infrastructures.Attributes;
using Microsoft.Extensions.Logging;
using Wizard.Cinema.Application.DTOs.Request.Activity;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Activity;
using Wizard.Cinema.Domain.Ministry;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs.Activity;

namespace Wizard.Cinema.Application.Services
{
    [Service]
    public class ActivityService : IActivityService
    {
        private readonly ILogger<IActivityService> _logger;

        private readonly IActivityRepository _activityRepository;
        private readonly IActivityQueryService _activityQueryService;

        private readonly IWizardQueryService _wizardQueryService;
        private readonly IDivisionRepository _divisionRepository;

        private readonly IApplicantQueryService _applicantQueryService;

        public ActivityService(ILogger<IActivityService> logger,
            IActivityRepository activityRepository,
            IActivityQueryService activityQueryService,
            IWizardQueryService wizardQueryService,
            IDivisionRepository divisionRepository,
            IApplicantQueryService applicantQueryService)
        {
            this._logger = logger;
            this._activityRepository = activityRepository;
            this._activityQueryService = activityQueryService;
            this._wizardQueryService = wizardQueryService;
            this._divisionRepository = divisionRepository;
            this._applicantQueryService = applicantQueryService;
        }

        public ApiResult<bool> Create(CreateActivityReqs request)
        {
            try
            {
                Divisions division = _divisionRepository.Query(request.DivisionId);
                if (division == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "找不到分部");

                long id = NewId.GenerateId();
                var activity = new Activity(id, request.DivisionId, request.Name, request.Description, request.Address,
                    request.BeginTime, request.FinishTime, request.RegistrationBeginTime, request.RegistrationFinishTime,
                    request.Price, request.CreatorId);

                if (_activityRepository.Insert(activity) <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "保存时出现问题，请稍后再试");

                return new ApiResult<bool>(ResultStatus.SUCCESS, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("创建活动异常", ex);
                return new ApiResult<bool>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<bool> Change(UpdateActivityReqs request)
        {
            try
            {
                Divisions division = _divisionRepository.Query(request.DivisionId);
                if (division == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "找不到分部");

                Activity activity = _activityRepository.Query(request.ActivityId);
                if (activity == null)
                    return new ApiResult<bool>(ResultStatus.FAIL, "找不到该活动");

                activity.Change(request.DivisionId, request.Name, request.Description, request.Address,
                    request.BeginTime, request.FinishTime, request.RegistrationBeginTime,
                    request.RegistrationFinishTime,
                    request.Price);

                if (_activityRepository.Update(activity) <= 0)
                    return new ApiResult<bool>(ResultStatus.FAIL, "保存时出现问题，请稍后再试");

                return new ApiResult<bool>(ResultStatus.SUCCESS, true);
            }
            catch (Exception ex)
            {
                _logger.LogError("修改活动异常", ex);
                return new ApiResult<bool>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<ActivityResp> GetById(long activityId)
        {
            if (activityId <= 0)
                return new ApiResult<ActivityResp>(ResultStatus.FAIL, "请选择正确的活动");

            ActivityInfo activity = _activityQueryService.Query(activityId);
            if (activity == null)
                return new ApiResult<ActivityResp>(ResultStatus.FAIL, "找不到该活动");

            return new ApiResult<ActivityResp>(ResultStatus.SUCCESS, Mapper.Map<ActivityInfo, ActivityResp>(activity));
        }

        public ApiResult<IEnumerable<ActivityResp>> GetByIds(long[] activityIds)
        {
            if (!activityIds.Any())
                return new ApiResult<IEnumerable<ActivityResp>>(ResultStatus.FAIL, "请选择正确的活动");

            IEnumerable<ActivityInfo> activity = _activityQueryService.Query(activityIds);

            return new ApiResult<IEnumerable<ActivityResp>>(ResultStatus.SUCCESS, Mapper.Map<ActivityInfo, ActivityResp>(activity));
        }

        public ApiResult<PagedData<ActivityResp>> Search(SearchActivityReqs request)
        {
            try
            {
                SearchActivityCondition search = Mapper.Map<SearchActivityReqs, SearchActivityCondition>(request);
                PagedData<ActivityInfo> activities = _activityQueryService.QueryPaged(search);
                return new ApiResult<PagedData<ActivityResp>>(ResultStatus.SUCCESS, Mapper.Map<PagedData<ActivityInfo>, PagedData<ActivityResp>>(activities));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询活动列表异常", ex);
                return new ApiResult<PagedData<ActivityResp>>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<ApplicantResp> GetApplicant(long applicantId)
        {
            try
            {
                ApplicantInfo applicant = _applicantQueryService.Query(applicantId);
                if (applicant == null)
                    return new ApiResult<ApplicantResp>(ResultStatus.FAIL, "该报名者不存在");

                return new ApiResult<ApplicantResp>(ResultStatus.SUCCESS, Mapper.Map<ApplicantInfo, ApplicantResp>(applicant));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询报名者异常", ex);
                return new ApiResult<ApplicantResp>(ResultStatus.EXCEPTION, ex.Message);
            }
        }

        public ApiResult<PagedData<ApplicantResp>> SearchApplicant(SearchApplicantReqs request)
        {
            try
            {
                SearchApplicantCondition search = Mapper.Map<SearchApplicantReqs, SearchApplicantCondition>(request);
                PagedData<ApplicantInfo> applicant = _applicantQueryService.QueryPaged(search);

                return new ApiResult<PagedData<ApplicantResp>>(ResultStatus.SUCCESS,
                    Mapper.Map<PagedData<ApplicantInfo>, PagedData<ApplicantResp>>(applicant));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询报名者异常", ex);
                return new ApiResult<PagedData<ApplicantResp>>(ResultStatus.EXCEPTION, new PagedData<ApplicantResp>(), ex.Message);
            }
        }

        public ApiResult<IEnumerable<ApplicantResp>> GetApplicantInActivity(long activityId)
        {
            try
            {
                IEnumerable<ApplicantInfo> applicants = _applicantQueryService.QueryByActivityId(activityId);
                return new ApiResult<IEnumerable<ApplicantResp>>(ResultStatus.SUCCESS, Mapper.Map<ApplicantInfo, ApplicantResp>(applicants));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询报名者异常", ex);
                return new ApiResult<IEnumerable<ApplicantResp>>(ResultStatus.EXCEPTION, Enumerable.Empty<ApplicantResp>(), ex.Message);
            }
        }

        public ApiResult<IEnumerable<ApplicantResp>> List(SearchApplicantReqs request)
        {
            try
            {
                SearchApplicantCondition search = Mapper.Map<SearchApplicantReqs, SearchApplicantCondition>(request);
                IEnumerable<ApplicantInfo> applicants = _applicantQueryService.Query(search);
                return new ApiResult<IEnumerable<ApplicantResp>>(ResultStatus.SUCCESS, Mapper.Map<ApplicantInfo, ApplicantResp>(applicants));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询报名者异常", ex);
                return new ApiResult<IEnumerable<ApplicantResp>>(ResultStatus.EXCEPTION, Enumerable.Empty<ApplicantResp>(), ex.Message);
            }
        }
    }
}
