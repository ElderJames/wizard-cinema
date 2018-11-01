using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Application.DTOs.Request.Activity;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Web.Extensions;

namespace Wizard.Cinema.Web.Controllers
{
    [Route("api/activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            this._activityService = activityService;
        }

        [HttpGet("")]
        public ActionResult List(int page = 1, int size = 10)
        {
            var applicantReq = new SearchApplicantReqs()
            {
                PageSize = size,
                PageNow = page
            };

            if (HttpContext.IsAuthenticated())
            {
                applicantReq.WizardId = HttpContext.User.ExtractUserId();
            }

            ApiResult<IEnumerable<ApplicantResp>> applicantResult = _activityService.List(applicantReq);
            if (applicantResult.Status != ResultStatus.SUCCESS)
                return Ok(Anonymous.ApiResult(ResultStatus.FAIL, applicantResult.Message));

            ApiResult<IEnumerable<ActivityResp>> activityResult = _activityService.GetByIds(applicantResult.Result.Select(x => x.ActivityId).ToArray());
            if (activityResult.Status != ResultStatus.SUCCESS)
                return Ok(Anonymous.ApiResult(ResultStatus.FAIL, activityResult.Message));

            return Ok(new ApiResult<object>(ResultStatus.SUCCESS, activityResult.Result.Select(x => new
            {
                x.ActivityId,
                x.Name,
                x.Status,
                x.Type,
            })));
        }
    }
}
