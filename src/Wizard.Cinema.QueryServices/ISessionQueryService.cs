using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.EnumTypes;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.QueryServices
{
    public interface ISessionQueryService
    {
        SessionInfo QueryBySessionId(long sessionId);

        SessionInfo QueryByActivityId(long activityId);

        PagedData<SessionInfo> QueryPaged(SearchSessionCondition search);

        IEnumerable<SessionInfo> Query(SessionStatus? status);
    }
}
