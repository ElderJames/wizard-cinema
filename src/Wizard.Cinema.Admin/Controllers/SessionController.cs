using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Remote.ApplicationServices;
using Wizard.Cinema.Remote.Models;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : BaseController
    {
        private readonly ISessionService _sessionService;
        private readonly IDivisionService _divisionService;
        private readonly HallService _hallService;

        public SessionController(ISessionService sessionService, IDivisionService divisionService,
            HallService hallService)
        {
            this._sessionService = sessionService;
            this._divisionService = divisionService;
            this._hallService = hallService;
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

            ApiResult<IEnumerable<DivisionResp>> divisions =
                _divisionService.GetByIds(sessionApi.Result.Records.Select(x => x.DivisionId).ToArray());

            return Ok(new
            {
                sessionApi.Result.PageNow,
                sessionApi.Result.PageSize,
                sessionApi.Result.TotalCount,
                Records = sessionApi.Result.Records.Select(x =>
                {
                    DivisionResp division = divisions.Result.FirstOrDefault(o => o.DivisionId == x.DivisionId);
                    return new
                    {
                        x.SessionId,
                        Cinema = x.CinemaId,
                        Hall = x.HallId,
                        Division = division?.Name,
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
    }
}
