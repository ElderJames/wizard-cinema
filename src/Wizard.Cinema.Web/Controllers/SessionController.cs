using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Application.DTOs.EnumTypes;
using Wizard.Cinema.Application.DTOs.Request.Session;
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
        private readonly ISelectSeatTaskService _selectSeatTaskService;

        public SessionController(ISeatService seatService, ISelectSeatTaskService selectSeatTaskService)
        {
            this._seatService = seatService;
            this._selectSeatTaskService = selectSeatTaskService;
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

        [HttpGet("tasks")]
        public IActionResult GetTasks(long sessionId)
        {
            if (sessionId <= 0)
                return Ok(new ApiResult<object>(ResultStatus.FAIL, "请选择正确的场次"));

            ApiResult<PagedData<SelectSeatTaskResp>> result = _selectSeatTaskService.Search(new SearchSelectSeatTaskReqs()
            {
                SessionId = sessionId,
                PageSize = int.MaxValue,
            });
            if (result.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<bool>(ResultStatus.FAIL, result.Message));

            //当前在选的巫师
            SelectSeatTaskResp currentWizard = result.Result.Records.FirstOrDefault(x => x.Status == SelectTaskStatus.进行中);
            SelectSeatTaskResp nextWizard = result.Result.Records.Where(x => x.SerialNo >= currentWizard.SerialNo).OrderBy(x => x.SerialNo).FirstOrDefault();
            SelectSeatTaskResp myTask = result.Result.Records.FirstOrDefault(x => x.WizardId == HttpContext?.User?.ExtractUserId());
            int people = result.Result.Records.Count(x => x.SerialNo >= currentWizard.SerialNo && x.SerialNo < myTask.SerialNo);
            int waitTime = people * 5;

            return Ok(new ApiResult<object>(ResultStatus.SUCCESS, new
            {
                current = currentWizard == null ? null : new
                {
                    currentWizard.BeginTime,
                    currentWizard.WechatName,
                    currentWizard.Total
                },
                next = nextWizard == null ? null : new
                {
                    nextWizard.BeginTime,
                    nextWizard.WechatName,
                    nextWizard.Total
                },
                my = new
                {
                    myTask.BeginTime,
                    myTask.WechatName,
                    myTask.Total,
                    waitTime = waitTime,
                    people = people
                },
                selectedList = result.Result.Records.Where(x => x.Status == SelectTaskStatus.已完成).SelectMany(x => x.SeatNos)
            }));
        }
    }
}
