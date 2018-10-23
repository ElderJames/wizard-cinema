using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Request.Session
{
    public class CreateSessionReqs
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 影院Id
        /// </summary>
        public int CinemaId { get; set; }

        /// <summary>
        /// 影厅Id
        /// </summary>
        public int HallId { get; set; }

        /// <summary>
        /// 选座模式
        /// </summary>
        public SelectMode SelectMode { get; set; }

        /// <summary>
        /// 锁定位置SeatNo
        /// </summary>
        public SeatInfoReqs[] Seats { get; set; }
    }
}
