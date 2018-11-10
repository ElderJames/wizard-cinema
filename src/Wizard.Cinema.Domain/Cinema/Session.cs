using Infrastructures;
using Infrastructures.Exceptions;
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

        /// <summary>
        /// 选座模式
        /// </summary>
        public SelectMode SelectMode { get; private set; }

        private Session()
        {
        }

        public Session(long sessionId, long divisionId, long activityId, int cinemaId, int hallId, SelectMode selectMode, string[] seatNos)
        {
            this.SessionId = sessionId;
            this.DivisionId = divisionId;
            this.ActivityId = activityId;
            this.CinemaId = cinemaId;
            this.HallId = hallId;
            this.SeatNos = seatNos;
            this.SelectMode = selectMode;
            this.Status = SessionStatus.编辑中;
        }

        public void Change(long divisionId, long activityId, int cinemaId, int hallId, string[] seatNos)
        {
            if (this.Status != SessionStatus.编辑中)
                throw new DomainException("场次" + this.Status.GetName());

            this.DivisionId = divisionId;
            this.ActivityId = activityId;
            this.CinemaId = cinemaId;
            this.HallId = hallId;
            this.SeatNos = seatNos;
        }

        public void Start()
        {
            if (this.Status != SessionStatus.编辑中)
                throw new DomainException($"该场次{this.Status.GetName()}，不能再启动");

            this.Status = SessionStatus.进行中;
        }

        public void Pause()
        {
            if (this.Status != SessionStatus.进行中)
                throw new DomainException($"该场次{this.Status.GetName()}，不能再暂停");

            this.Status = SessionStatus.已暂停;
        }

        public void Continue()
        {
            if (this.Status != SessionStatus.已暂停)
                throw new DomainException($"该场次{this.Status.GetName()}，不能再继续");

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
