using System.Collections.Generic;

namespace Wizard.Cinema.Domain.Cinema
{
    public interface ISeatRepository
    {
        int Insert(Seat seat);

        int BatchInsert(Seat[] seats);

        int BatchUpdate(Seat[] seats);

        int ClearInSession(long sessionId);

        int Choose(Seat seat);

        Seat Query(long seatId);

        IEnumerable<Seat> Query(long sessionId, string[] seatNos);
    }
}
