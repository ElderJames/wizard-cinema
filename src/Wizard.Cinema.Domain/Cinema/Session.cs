using Wizard.Cinema.Domain.Cinema.EnumTypes;

namespace Wizard.Cinema.Domain.Cinema
{
    /// <summary>
    /// 场次
    /// </summary>
    public class Session
    {
        /// <summary>
        /// 场次Id
        /// </summary>
        public long SessionId { get; private set; }

        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; private set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; private set; }

        /// <summary>
        /// 影院Id
        /// </summary>
        public int CinemaId { get; private set; }

        /// <summary>
        /// 影厅Id
        /// </summary>
        public int HallId { get; private set; }

        /// <summary>
        /// 锁定位置SeatNo
        /// </summary>
        public string[] SeatNos { get; private set; }

        /// <summary>
        /// 状态
        /// </summary>
        public SessionStatus Status { get; private set; }

        private Session()
        {
        }

        public Session(long sessionId, long divisionId, long activityId, int cinemaId, int hallId, string[] seatNos)
        {
            this.SessionId = sessionId;
            this.DivisionId = divisionId;
            this.ActivityId = activityId;
            this.CinemaId = cinemaId;
            this.HallId = hallId;
            this.SeatNos = seatNos;
            this.Status = SessionStatus.编辑中;
        }

        public void Change(int cinemaId, int hallId, string[] seatNos)
        {
            this.CinemaId = cinemaId;
            this.HallId = hallId;
            this.SeatNos = seatNos;
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
