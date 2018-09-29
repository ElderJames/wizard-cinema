namespace Wizard.Cinema.Application.DTOs.Request.Session
{
    public class UpdateSessionReqs
    {
        /// <summary>
        /// 场次Id
        /// </summary>
        public long SessionId { get; set; }

        /// <summary>
        /// 分部Id
        /// </summary>
        public long DivisionId { get; set; }

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
