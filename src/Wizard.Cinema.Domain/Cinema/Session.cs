using System.Collections.Generic;
using System.Linq;
using Infrastructures.Exceptions;
using Wizard.Cinema.Domain.Cinema.EnumTypes;

namespace Wizard.Cinema.Domain.Cinema
{
    /// <summary>
    /// 场次
    /// </summary>
    public class Session
    {
        public long SessionId { get; private set; }

        public long DivisionId { get; private set; }

        public string Cinema { get; private set; }

        public string Hall { get; private set; }

        public IEnumerable<long[]> Seats { get; private set; }

        public SessionStatus Status { get; private set; }

        public Session(long sessionId, long divisionId, string cinema, string hall, IEnumerable<long[]> seats)
        {
            if (seats.Any(x => x.Length != 2 || !x.All(o => o > 0)))
                throw new DomainException("座位的格式不正确");

            this.SessionId = sessionId;
            this.DivisionId = divisionId;
            this.Cinema = cinema;
            this.Hall = hall;
            this.Seats = seats;
            this.Status = SessionStatus.编辑中;
        }

        public void Start()
        {
            this.Status = SessionStatus.进行中;
        }

        public void Stop()
        {
            this.Status = SessionStatus.编辑中;
        }

        public void MarkFull()
        {
            this.Status = SessionStatus.已满员;
        }
    }
}
