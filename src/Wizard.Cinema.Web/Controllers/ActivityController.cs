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
        private ISessionService _sessionService;

        public ActivityController(IActivityService activityService,
            ISessionService sessionService)
        {
            this._activityService = activityService;
            this._sessionService = sessionService;
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
                x.Summary,
                x.Thumbnail
            })));
        }

        [HttpGet("{activityId}/session")]
        public IActionResult Hall(long activityId)
        {
            if (activityId <= 0)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "请选择活动"));

            ApiResult<ActivityResp> activityResult = _activityService.GetById(activityId);
            if (activityResult.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, activityResult.Message));

            ApiResult<SessionResp> sessionResult = _sessionService.GetSessionByActivityId(activityId);
            if (sessionResult.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, sessionResult.Message));

            if (sessionResult.Result == null)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "找不到场次"));

            return Ok(new ApiResult<object>(ResultStatus.SUCCESS, new
            {
                sessionResult.Result.ActivityId,
                sessionResult.Result.SessionId,
                activityResult.Result.Name,
                activityResult.Result.Summary,
                sessionResult.Result.HallId,
                sessionResult.Result.SeatNos,
                sessionResult.Result.CinemaId
            }));
        }
    }
}
