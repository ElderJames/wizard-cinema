using System;
using Infrastructures;
using Infrastructures.Attributes;
using Microsoft.Extensions.Logging;
using Wizard.Cinema.Application.DTOs.Request.Activity;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Activity;
using Wizard.Cinema.QueryServices;

namespace Wizard.Cinema.Application.Services
{
    [Impl]
    public class ActivityService : IActivityService
    {
        private ILogger<IActivityService> _logger;

        private IActivityRepository _activityRepository;
        private IActivityQueryService _activityQueryService;

        private IWizardQueryService _wizardQueryService;

        public ActivityService(ILogger<IActivityService> logger,
            IActivityRepository activityRepository,
            IActivityQueryService activityQueryService,
            IWizardQueryService wizardQueryService)
        {
            this._logger = logger;
            this._activityRepository = activityRepository;
            this._activityQueryService = activityQueryService;
            this._wizardQueryService = wizardQueryService;
        }

        public ApiResult<bool> Create(CreateActivityReqs request)
        {
            throw new NotImplementedException();
        }

        public ApiResult<bool> Change(CreateActivityReqs request)
        {
            throw new NotImplementedException();
        }

        public ApiResult<ActivityResp> GetById(long activityId)
        {
            throw new NotImplementedException();
        }

        public ApiResult<PagedData<ActivityResp>> Search(PagedSearch search)
        {
            throw new NotImplementedException();
        }
    }
}
