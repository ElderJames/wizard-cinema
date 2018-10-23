using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.QueryServices.DTOs.Cinema
{
    public class SeatInfo
    {
        /// <summary>
        /// 座位Id
        /// </summary>
        public long SeatId { get; set; }

        /// <summary>
        /// 场次Id
        /// </summary>
        public long SessionId { get; set; }

        /// <summary>
        /// 活动id
        /// </summary>
        public long ActivityId { get; set; }

        /// <summary>
        /// 影院提供的座位编号
        /// </summary>
        public string SeatNo { get; set; }

        /// <summary>
        /// 位置，n排m坐
        /// </summary>
        public string[] Position { get; set; }

        /// <summary>
        /// 是否已选
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// 选座巫师Id
        /// </summary>
        public long? WizardId { get; set; }

        /// <summary>
        /// 选座时间
        /// </summary>
        public DateTime? SelectTime { get; set; }
    }
}
