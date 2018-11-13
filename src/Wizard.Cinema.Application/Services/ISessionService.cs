using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.EnumTypes;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;

namespace Wizard.Cinema.Application.Services
{
    public interface ISessionService
    {
        ApiResult<bool> Create(CreateSessionReqs request);

        ApiResult<bool> Change(UpdateSessionReqs request);

        ApiResult<SessionResp> GetSession(long sessionId);

        ApiResult<IEnumerable<SessionResp>> GetSessions(SessionStatus? status = null);

        ApiResult<SessionResp> GetSessionByActivityId(long activityId);

        ApiResult<PagedData<SessionResp>> SearchSession(SearchSessionReqs search);

        ApiResult<bool> BeginSelectSeat(long sessionId);

        ApiResult<bool> PauseSelectSeat(long sessionId);

        ApiResult<bool> ContinueSelectSeat(long sessionId);

        ApiResult<bool> Enqueue(long sessionId);
    }
}
