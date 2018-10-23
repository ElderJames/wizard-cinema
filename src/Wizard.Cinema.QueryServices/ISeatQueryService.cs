using System.Collections.Generic;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.QueryServices
{
    public interface ISeatQueryService
    {
        SeatInfo QueryBySeatId(long seatId);

        SeatInfo[] QueryBySessionId(long sessionId);

        IEnumerable<SeatInfo> QueryByActivityId(long activityId);

        string[] QuerySeatNos(long sessionId, long wizardId);
    }
}
