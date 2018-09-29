using System.Collections.Generic;
using System.Linq;
using Infrastructures;
using Microsoft.AspNetCore.Mvc;
using Wizard.Cinema.Admin.Models;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Application.Services;
using Wizard.Cinema.Application.Services.Dto.Response;

namespace Wizard.Cinema.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : BaseController
    {
        private readonly ISessionService _sessionService;
        private readonly IDivisionService _divisionService;

        public SessionController(ISessionService sessionService, IDivisionService divisionService)
        {
            this._sessionService = sessionService;
            this._divisionService = divisionService;
        }

        [HttpGet("{id:long}")]
        public IActionResult GetSession(long id)
        {
            ApiResult<SessionResp> sessionApi = _sessionService.GetSession(id);
            return Json(sessionApi);
        }

        [HttpGet]
        public IActionResult Search([FromQuery]SearchSessionReqs search)
        {
            ApiResult<PagedData<SessionResp>> sessionApi = _sessionService.SearchSession(search);
            if (sessionApi.Status != ResultStatus.SUCCESS)
                return Ok(new PagedData<SessionResp>());

            ApiResult<IEnumerable<DivisionResp>> divisions = _divisionService.GetByIds(sessionApi.Result.Records.Select(x => x.DivisionId).ToArray());

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
            if (!model.SessionId.HasValue || model.SessionId <= 0)
            {
                ApiResult<bool> apiResult = _sessionService.Create(new CreateSessionReqs()
                {
                    DivisionId = model.DivisionId,
                    CinemaId = model.CinemaId,
                    HallId = model.HallId,
                    SeatNos = model.SeatNos
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
                    SeatNos = model.SeatNos
                });

                return Json(apiResult);
            }
        }
    }
}
