using System.ComponentModel.DataAnnotations;

namespace Wizard.Cinema.Admin.Models
{
    public class SessionModel
    {
        /// <summary>
        /// 场次Id
        /// </summary>
        public long? SessionId { get; set; }

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
        /// 锁定位置SeatNo
        /// </summary>
        public string[] SeatNos { get; set; }
    }
}
