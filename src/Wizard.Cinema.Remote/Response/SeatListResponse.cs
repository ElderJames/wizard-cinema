using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Remote.Response
{
    /// <summary>
    /// 座位表
    /// </summary>
    public class SeatListResponse
    {
        public Seatdata seatData { get; set; }

        public class Seatdata
        {
            public Cinema cinema { get; set; }
            public Hall hall { get; set; }
            public Seat seat { get; set; }
            public Show show { get; set; }
        }

        public class Cinema
        {
            public int cinemaId { get; set; }
            public string cinemaName { get; set; }
        }

        public class Hall
        {
            public int hallId { get; set; }
            public string hallName { get; set; }
        }

        public class Seat
        {
            public Section[] sections { get; set; }
        }

        public class Section
        {
            public int cols { get; set; }
            public int rows { get; set; }
            public SeatItem[] seats { get; set; }
            public string sectionId { get; set; }
            public string sectionName { get; set; }
        }

        public class SeatItem
        {
            public Column[] columns { get; set; }
            public string rowId { get; set; }
            public int rowNum { get; set; }
        }

        public class Column
        {
            public string columnId { get; set; }
            public string seatNo { get; set; }
            public string st { get; set; }
        }

        public class Show
        {
            public int buyNumLimit { get; set; }
            public string dim { get; set; }
            public string lang { get; set; }
            public int langWarn { get; set; }
            public string seqNo { get; set; }
            public string showDate { get; set; }
            public int showId { get; set; }
            public string showTime { get; set; }
            public string watermark { get; set; }
        }
    }
}