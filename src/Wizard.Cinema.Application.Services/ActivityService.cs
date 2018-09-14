using System;
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
    [Impl]
    public class ActivityService : IActivityService
    {
        private readonly ILogger<IActivityService> _logger;

        private readonly IActivityRepository _activityRepository;
        private readonly IActivityQueryService _activityQueryService;

        private readonly IWizardQueryService _wizardQueryService;
        private readonly IDivisionRepository divisionRepository;

        public ActivityService(ILogger<IActivityService> logger,
            IActivityRepository activityRepository,
            IActivityQueryService activityQueryService,
            IWizardQueryService wizardQueryService,
            IDivisionRepository divisionRepository)
        {
            this._logger = logger;
            this._activityRepository = activityRepository;
            this._activityQueryService = activityQueryService;
            this._wizardQueryService = wizardQueryService;
            this.divisionRepository = divisionRepository;
        }

        public ApiResult<bool> Create(CreateActivityReqs request)
        {
            try
            {
                Divisions division = divisionRepository.Query(request.DivisionId);
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
                Divisions division = divisionRepository.Query(request.DivisionId);
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

        public ApiResult<PagedData<ActivityResp>> Search(PagedSearch search)
        {
            try
            {
                PagedData<ActivityInfo> activities = _activityQueryService.QueryPaged(search);
                return new ApiResult<PagedData<ActivityResp>>(ResultStatus.SUCCESS, Mapper.Map<PagedData<ActivityInfo>, PagedData<ActivityResp>>(activities));
            }
            catch (Exception ex)
            {
                _logger.LogError("查询活动列表异常", ex);
                return new ApiResult<PagedData<ActivityResp>>(ResultStatus.EXCEPTION, ex.Message);
            }
        }
    }
}
