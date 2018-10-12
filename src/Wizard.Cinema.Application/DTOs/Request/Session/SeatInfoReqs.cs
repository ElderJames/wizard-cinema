using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Application.DTOs.Request.Session
{
    public class SeatInfoReqs
    {
        public string SeatNo { get; set; }

        public string RowId { get; set; }

        public string ColumnId { get; set; }
    }
}
