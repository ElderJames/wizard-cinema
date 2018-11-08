using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Helpers;
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
        public IActionResult Search([FromQuery]SearchActivityModel model)
        {
            SearchActivityReqs search = Mapper.Map<SearchActivityModel, SearchActivityReqs>(model);
            ApiResult<PagedData<ActivityResp>> activitys = _activityService.Search(search);
            ApiResult<IEnumerable<DivisionResp>> divisionResult = _divisionService.GetByIds(activitys.Result.Records.Select(x => x.DivisionId).ToArray());
            ApiResult<IEnumerable<WizardResp>> wizards = _wizardService.GetWizards(activitys.Result.Records.Select(x => x.CreatorId).ToArray());

            return Ok(new
            {
                activitys.Result.PageNow,
                activitys.Result.PageSize,
                activitys.Result.TotalCount,
                Records = activitys.Result.Records.Select(x =>
                {
                    DivisionResp division = divisionResult.Result.FirstOrDefault(d => d.DivisionId == x.DivisionId);
                    WizardResp creator = wizards.Result.FirstOrDefault(u => u.WizardId == x.CreatorId);
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

        [HttpGet("applicants/{id:long}")]
        public IActionResult GetApplicant(long id)
        {
            if (id <= 0)
                return Fail("请选择正确的报名者");

            ApiResult<ApplicantResp> applicantApi = _activityService.GetApplicant(id);
            if (applicantApi.Result == null)
                return Fail("找不到该报名者");

            return Ok(applicantApi.Result);
        }

        [HttpGet("{activityId:long}/applicants")]
        public IActionResult SearchApplicant(long activityId, [FromQuery]SearchApplicantReqs search)
        {
            search.ActivityId = activityId;

            ApiResult<PagedData<ApplicantResp>> applicantApi = _activityService.SearchApplicant(search);
            if (!applicantApi.Result.Records.Any())
                return Ok(new PagedData<ApplicantResp>());

            ApiResult<IEnumerable<DivisionResp>> divisionResult = _divisionService.GetByIds(applicantApi.Result.Records.Select(x => x.DivisionId).ToArray());
            ApiResult<IEnumerable<WizardResp>> wizards = _wizardService.GetWizards(applicantApi.Result.Records.Select(x => x.WizardId).ToArray());
            ApiResult<IEnumerable<ActivityResp>> activitys = _activityService.GetByIds(applicantApi.Result.Records.Select(x => x.ActivityId).ToArray());

            return Ok(new
            {
                applicantApi.Result.PageNow,
                applicantApi.Result.PageSize,
                applicantApi.Result.TotalCount,
                Records = applicantApi.Result.Records.Select(x =>
                {
                    DivisionResp division = divisionResult.Result.FirstOrDefault(d => d.DivisionId == x.DivisionId);
                    WizardResp wizard = wizards.Result.FirstOrDefault(u => u.WizardId == x.WizardId);
                    ActivityResp activity = activitys.Result.FirstOrDefault(a => a.ActivityId == x.ActivityId);
                    return new
                    {
                        x.ApplicantId,
                        Activity = activity?.Name,
                        WizardName = wizard?.Account,
                        Division = division?.Name,
                        x.ApplyTime,
                        x.Mobile,
                        x.RealName,
                        Status = x.Status.GetName()
                    };
                })
            });
        }

        [HttpPost("{activityId:long}/applicants/import-from-weidian")]
        public IActionResult ImportApplicant(long activityId)
        {
            if (Request.Form.Files.Count <= 0)
                return Fail("还没上传文件");

            IFormFile file = Request.Form.Files[0];
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);

            List<ImportWedianApplicantModel> model = ExcelHelper.InputExcel<ImportWedianApplicantModel>(file);
            var req = new ImportApplicantReqs()
            {
                ActivityId = activityId,
                Data = Mapper.Map<ImportWedianApplicantModel, ImportData>(model)
            };
            ApiResult<bool> result = _activityService.ImportApplicants(req);
            return Json(result);
        }
    }
}
