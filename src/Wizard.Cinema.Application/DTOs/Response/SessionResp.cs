using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Response
{
    public class SessionResp
    {
        /// <summary>
        /// 场次Id
        /// </summary>
        public long SessionId { get; set; }

        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; set; }

        /// <summary>
        /// 影院Id
        /// </summary>
        public long CinemaId { get; set; }

        /// <summary>
        /// 影厅Id
        /// </summary>
        public long HallId { get; set; }

        /// <summary>
        /// 锁定位置SeatNo
        /// </summary>
        public string[] SeatNos { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public SessionStatus Status { get; set; }
    }
}
