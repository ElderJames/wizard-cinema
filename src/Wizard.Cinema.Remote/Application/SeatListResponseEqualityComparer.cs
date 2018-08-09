using System.Collections.Generic;
using Wizard.Cinema.Remote.Spider.Response;

namespace Wizard.Cinema.Remote.Application
{
    public class SeatListResponseEqualityComparer : IEqualityComparer<SeatListResponse>
    {
        public bool Equals(SeatListResponse x, SeatListResponse y)
        {
            return x.seatData?.hall?.hallId == y.seatData?.hall?.hallId;
        }

        public int GetHashCode(SeatListResponse obj)
        {
            return obj.seatData?.hall?.hallId ?? 0;
        }
    }
}