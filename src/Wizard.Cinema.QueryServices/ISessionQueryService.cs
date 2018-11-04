using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.QueryServices
{
    public interface ISessionQueryService
    {
        SessionInfo QueryBySessionId(long sessionId);

        SessionInfo QueryByActivityId(long activityId);

        PagedData<SessionInfo> QueryPaged(SearchSessionCondition search);
    }
}
