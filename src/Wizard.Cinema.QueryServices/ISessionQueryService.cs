using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.QueryServices
{
    public interface ISessionQueryService
    {
        SessionInfo Query(long sessionId);

        PagedData<SessionInfo> QueryPaged(SearchSessionCondition search);
    }
}
