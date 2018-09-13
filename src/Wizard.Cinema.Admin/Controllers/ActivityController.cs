using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.DTOs.Request.Activity;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Response;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : BaseController
    {
        private readonly IActivityService _activityService;
        private readonly IDivisionService _divisionService;
        private readonly IWizardService _wizardService;

        public ActivityController(IActivityService activityService, IDivisionService divisionService, IWizardService wizardService)
        {
            this._activityService = activityService;
            this._divisionService = divisionService;
            this._wizardService = wizardService;
        }

        [HttpGet("{activityId:long}")]
        public IActionResult Get(long activityId)
        {
            if (activityId <= 0)
                return Fail("请选择正确的活动");

            ApiResult<ActivityResp> activity = _activityService.GetById(activityId);
            if (activity.Result == null)
                return Fail("找不到该活动");

            return Ok(Mapper.Map<ActivityResp, ActivityModel>(activity.Result));
        }

        [HttpPost("")]
        public IActionResult Edit(ActivityModel model)
        {
            ApiResult<DivisionResp> divisionResult = _divisionService.GetById(model.DivisionId);

            if (divisionResult.Status != ResultStatus.SUCCESS || divisionResult.Result == null)
                return Fail("请选择正确的分部");

            if (!model.ActivityId.HasValue || model.ActivityId <= 0)
            {
                ApiResult<bool> result = _activityService.Create(new CreateActivityReqs()
                {
                    DivisionId = model.DivisionId,
                    Name = model.Name,
                    Description = model.Description,
                    Address = model.Address,
                    Price = model.Price,
                    BeginTime = model.BeginTime,
                    FinishTime = model.FinishTime,
                    RegistrationBeginTime = model.RegistrationBeginTime,
                    RegistrationFinishTime = model.RegistrationFinishTime,
                    CreatorId = CurrentUser.UserId
                });

                return Json(result);
            }
            else
            {
                ApiResult<ActivityResp> activity = _activityService.GetById(model.ActivityId.Value);
                if (activity.Result == null)
                    return Fail("找不到该活动");

                ApiResult<bool> result = _activityService.Change(new UpdateActivityReqs()
                {
                    ActivityId = model.ActivityId.Value,
                    DivisionId = model.DivisionId,
                    Name = model.Name,
                    Description = model.Description,
                    Address = model.Address,
                    Price = model.Price,
                    BeginTime = model.BeginTime,
                    FinishTime = model.FinishTime,
                    RegistrationBeginTime = model.RegistrationBeginTime,
                    RegistrationFinishTime = model.RegistrationFinishTime,
                });

                return Json(result);
            }
        }

        [HttpGet]
        public IActionResult Search([FromQuery]PagedSearch search)
        {
            ApiResult<PagedData<ActivityResp>> activitys = _activityService.Search(search);
            ApiResult<IEnumerable<DivisionResp>> divisionResult = _divisionService.GetByIds(activitys.Result.Records.Select(x => x.DivisionId).ToArray());
            ApiResult<IEnumerable<WizardResp>> users = _wizardService.GetWizards(activitys.Result.Records.Select(x => x.CreatorId).ToArray());

            return Ok(new
            {
                activitys.Result.PageNow,
                activitys.Result.PageSize,
                activitys.Result.TotalCount,
                Records = activitys.Result.Records.Select(x =>
                {
                    DivisionResp division = divisionResult.Result.FirstOrDefault(d => d.DivisionId == x.DivisionId);
                    WizardResp creator = users.Result.FirstOrDefault(u => u.WizardId == x.CreatorId);
                    return new
                    {
                        x.ActivityId,
                        x.DivisionId,
                        x.Name,
                        x.BeginTime,
                        x.FinishTime,
                        x.RegistrationBeginTime,
                        x.RegistrationFinishTime,
                        Status = x.Status.GetName(),
                        Division = division?.Name,
                        Creator = creator?.Account
                    };
                })
            });
        }
    }
}
