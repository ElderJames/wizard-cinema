using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Web.Extensions;
using Wizard.Cinema.Web.Models;

namespace Wizard.Cinema.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SessionController(ISeatService seatService)
        {
            this._seatService = seatService;
        }

        [HttpPost("select-seats")]
        public IActionResult Select(SelectSeatModel model)
        {
            ApiResult<bool> result = _seatService.Select(HttpContext?.User?.ExtractUserId() ?? 0, model.SessionId, model.SeatNos);
            if (result.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<bool>(ResultStatus.FAIL, result.Message));

            return Ok(new ApiResult<bool>(ResultStatus.SUCCESS, true));
        }

        [HttpGet("seats")]
        public IActionResult SeatList(long sessionId)
        {
            if (sessionId <= 0)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "请选择正确的场次"));

            ApiResult<IEnumerable<SeatResp>> result = _seatService.GetBySession(sessionId);
            if (result.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<bool>(ResultStatus.FAIL, result.Message));

            return Ok(new ApiResult<object>(ResultStatus.SUCCESS, result.Result.Select(x => new
            {
                x.ActivityId,
                x.Position,
                x.SeatId,
                x.SeatNo,
                x.WizardId,
                x.Selected,
            })));
        }
    }
}
