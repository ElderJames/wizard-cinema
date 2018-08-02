using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Remote.Models
{
    //影厅
    public class Hall
    {
        public int Id { get; set; }

        /// <summary>
        /// 影厅Id
        /// </summary>
        public int HallId { get; set; }

        /// <summary>
        /// 影厅名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 影院Id
        /// </summary>
        public int CinemaId { get; set; }

        /// <summary>
        /// 座位html
        /// </summary>
        public string SeatHtml { get; set; }

        /// <summary>
        /// 座位json
        /// </summary>
        public string SeatJson { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}