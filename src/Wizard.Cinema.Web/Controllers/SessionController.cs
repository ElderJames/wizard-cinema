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
        private ISessionService _sessionService;

        public SessionController(ISeatService seatService,
            ISelectSeatTaskService selectSeatTaskService,
            ISessionService sessionService)
        {
            this._seatService = seatService;
            this._selectSeatTaskService = selectSeatTaskService;
            this._sessionService = sessionService;
        }

        [HttpPost("select-seats")]
        public IActionResult Select(SelectSeatModel model)
        {
            long wizardId = (long)HttpContext?.User?.ExtractUserId();
            ApiResult<bool> result = _seatService.Select(model.SessionId, wizardId, model.TaskId, model.SeatNos);
            if (result.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<bool>(ResultStatus.FAIL, result.Message));

            return Ok(new ApiResult<bool>(ResultStatus.SUCCESS, true));
        }

        [HttpGet("{sessionId:long}/seats")]
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

        [HttpGet("{sessionId:long}/tasks")]
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
            if (currentWizard == null)
                return Ok(new ApiResult<bool>(ResultStatus.FAIL, "没有巫师在选，系统可能出错了"));
            SelectSeatTaskResp nextWizard = result.Result.Records.Where(x => x.TaskId != currentWizard.TaskId && x.SerialNo >= currentWizard.SerialNo).OrderBy(x => x.SerialNo).FirstOrDefault();
            IEnumerable<SelectSeatTaskResp> myTasks = result.Result.Records.Where(x => x.WizardId == HttpContext?.User?.ExtractUserId()).OrderBy(x => x.SerialNo);
            SelectSeatTaskResp myFirst = myTasks.FirstOrDefault();
            SelectSeatTaskResp canSelectTask = myTasks.OrderBy(x => x.SerialNo).FirstOrDefault(x => x.Status == SelectTaskStatus.进行中);
            string[] selectedSeatNos = result.Result.Records.Where(x => x.Status == SelectTaskStatus.已完成).SelectMany(x => x.SeatNos).ToArray();

            return Ok(new ApiResult<object>(ResultStatus.SUCCESS, new
            {
                myFirst?.WechatName,
                overdueTasks = myTasks.Where(x => x.Status == SelectTaskStatus.超时未重排 || x.Status == SelectTaskStatus.超时已重排).Select(x => new
                {
                    x.TaskId,
                    x.OverdueTaskId,
                    x.EndTime,
                }),
                canSelectTask = canSelectTask == null ? null : new
                {
                    canSelectTask.BeginTime,
                    canSelectTask.Total,
                    canSelectTask.TaskId
                },
                myTasks = myTasks.OrderByDescending(x => x.EndTime).Select(x => new
                {
                    x.EndTime,
                    x.SeatNos,
                    Status = x.Status.GetName(),
                }),
                unfinishedTasks = myTasks.Where(x => x.Status != SelectTaskStatus.超时已重排 && x.Status != SelectTaskStatus.已完成)
                    .Select(x =>
                    {
                        int people = result.Result.Records.Count(o => x.TaskId != o.TaskId && x.SerialNo >= currentWizard.SerialNo && o.SerialNo < x.SerialNo);

                        return new
                        {
                            x.BeginTime,
                            x.Total,
                            x.SerialNo,
                            Status = x.Status.GetName(),
                            People = people,
                            WaitTime = people * 5
                        };
                    }),
                current = currentWizard == null
                    ? null
                    : new
                    {
                        currentWizard.BeginTime,
                        currentWizard.WechatName,
                        currentWizard.Total
                    },
                next = nextWizard == null
                    ? null
                    : new
                    {
                        nextWizard.BeginTime,
                        nextWizard.WechatName,
                        nextWizard.Total
                    },
                selectedList = selectedSeatNos
            }));
        }

        [HttpPost("{sessionId:long}/checkIn")]
        public IActionResult CheckIn(long sessionId)
        {
            if (sessionId <= 0)
                return Ok(new ApiResult<bool>(ResultStatus.FAIL, "请选择正确的场次"));
            long wizardId = (long)HttpContext?.User?.ExtractUserId();
            ApiResult<bool> result = _selectSeatTaskService.CheckIn(wizardId, sessionId);
            if (result.Status != ResultStatus.SUCCESS)
                return Ok(new ApiResult<bool>(ResultStatus.FAIL, result.Message));
            return Ok(new ApiResult<bool>(ResultStatus.SUCCESS, true));
        }
    }
}
