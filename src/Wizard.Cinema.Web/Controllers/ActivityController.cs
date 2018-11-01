using System.Collections.Generic;
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
        private IActivityService _activityService;
        private IApplicantService _applicantService;

        public ActivityController(IActivityService activityService,
            IApplicantService applicantService)
        {
            this._activityService = activityService;
            this._applicantService = applicantService;
        }

        [HttpGet("")]
        public ActionResult List(int page, int size)
        {
            var ApplicantReq = new SearchApplicantReqs()
            {
                PageSize = size,
                PageNow = page
            };

            if (HttpContext.IsAuthenticated())
            {
                ApplicantReq.WizardId = HttpContext.User.ExtractUserId() ?? 0;
            }

            ApiResult<IEnumerable<ApplicantResp>> applicantResult = _applicantService.List(ApplicantReq);
            if (applicantResult.Status != ResultStatus.SUCCESS)
                return Ok(Anonymous.ApiResult(ResultStatus.FAIL, applicantResult.Message));

            return Ok(Anonymous.ApiResult(ResultStatus.SUCCESS, new { }));
        }
    }
}
