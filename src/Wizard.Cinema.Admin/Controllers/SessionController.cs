using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.QueryServices.DTOs.Activity;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SessionController : BaseController
    {
        private readonly ISessionService _sessionService;
        private readonly IDivisionService _divisionService;
        private readonly HallService _hallService;
        private CinemaService _cinemaService;
        private IActivityService _activityService;

        public SessionController(ISessionService sessionService,
            IDivisionService divisionService,
            HallService hallService, CinemaService cinemaService, IActivityService activityService)
        {
            this._sessionService = sessionService;
            this._divisionService = divisionService;
            this._hallService = hallService;
            this._cinemaService = cinemaService;
            this._activityService = activityService;
        }

        [HttpGet("{id:long}")]
        public IActionResult GetSession(long id)
        {
            ApiResult<SessionResp> sessionApi = _sessionService.GetSession(id);
            return Json(sessionApi);
        }

        [HttpGet]
        public IActionResult Search([FromQuery] SearchSessionReqs search)
        {
            ApiResult<PagedData<SessionResp>> sessionApi = _sessionService.SearchSession(search);
            if (sessionApi.Status != ResultStatus.SUCCESS)
                return Ok(new PagedData<SessionResp>());

            ApiResult<IEnumerable<DivisionResp>> divisions = _divisionService.GetByIds(sessionApi.Result.Records.Select(x => x.DivisionId).ToArray());
            ApiResult<IEnumerable<Remote.Models.Cinema>> cinemas = _cinemaService.GetByIds(sessionApi.Result.Records.Select(x => x.CinemaId));
            ApiResult<IEnumerable<ActivityResp>> activityList = _activityService.GetByIds(sessionApi.Result.Records.Select(x => x.ActivityId).ToArray());
            ApiResult<IEnumerable<Hall>> hallList = _hallService.GetByIds(sessionApi.Result.Records.Select(o => o.HallId));

            return Ok(new
            {
                sessionApi.Result.PageNow,
                sessionApi.Result.PageSize,
                sessionApi.Result.TotalCount,
                Records = sessionApi.Result.Records.Select(x =>
                {
                    DivisionResp division = divisions.Result.FirstOrDefault(o => o.DivisionId == x.DivisionId);
                    Remote.Models.Cinema cinema = cinemas.Result.FirstOrDefault(o => o.CinemaId == x.CinemaId);
                    ActivityResp activity = activityList.Result.FirstOrDefault(o => o.ActivityId == x.ActivityId);
                    Hall hall = hallList.Result.FirstOrDefault(o => o.HallId == x.HallId);
                    return new
                    {
                        x.SessionId,
                        Division = division?.Name,
                        Cinema = cinema?.Name,
                        Hall = hall?.Name,
                        Activity = activity?.Name,
                        Status = x.Status.GetName(),
                    };
                })
            });
        }

        [HttpPost]
        public IActionResult Edit(SessionModel model)
        {
            Hall hall = _hallService.GetById(model.HallId);
            if (hall == null)
                return Fail("找不到影厅信息");

            SeatListResponse.Seat seat = JsonConvert.DeserializeObject<SeatListResponse.Seat>(hall.SeatJson);

            if (!model.SessionId.HasValue || model.SessionId <= 0)
            {
                ApiResult<bool> apiResult = _sessionService.Create(new CreateSessionReqs()
                {
                    ActivityId = model.ActivityId,
                    CinemaId = model.CinemaId,
                    HallId = model.HallId,
                    Seats = model.SeatNos.SelectMany(seatNo => seat.sections[0].seats.SelectMany(o =>
                            o.columns.Select(x => new
                            {
                                x.seatNo,
                                o.rowId,
                                x.columnId
                            }))
                        .Where(x => x.seatNo == seatNo)
                        .Select(o => new SeatInfoReqs
                        {
                            SeatNo = seatNo,
                            ColumnId = o.columnId,
                            RowId = o.rowId
                        })).ToArray()
                });

                return Json(apiResult);
            }
            else
            {
                ApiResult<bool> apiResult = _sessionService.Change(new UpdateSessionReqs()
                {
                    ActivityId = model.ActivityId,
                    SessionId = model.SessionId.Value,
                    CinemaId = model.CinemaId,
                    HallId = model.HallId,
                    Seats = model.SeatNos.SelectMany(seatNo => seat.sections[0].seats.SelectMany(o =>
                            o.columns.Select(x => new
                            {
                                x.seatNo,
                                o.rowId,
                                x.columnId
                            }))
                        .Where(x => x.seatNo == seatNo)
                        .Select(o => new SeatInfoReqs
                        {
                            SeatNo = seatNo,
                            ColumnId = o.columnId,
                            RowId = o.rowId
                        })).ToArray()
                });

                return Json(apiResult);
            }
        }

        [HttpPost("begin-select")]
        public IActionResult BeginSelect([FromForm]long sessionId)
        {
            if (sessionId <= 0)
                return Fail("请选择正确的场次");

            ApiResult<bool> result = _sessionService.BeginSelectSeat(sessionId);
            if (result.Status != ResultStatus.SUCCESS || !result.Result)
                return Fail(result.Message);

            return Ok();
        }
    }
}
