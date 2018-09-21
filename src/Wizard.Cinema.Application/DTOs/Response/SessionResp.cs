using System.Collections.Generic;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Response
{
    public class SessionResp
    {
        public long SessionId { get; set; }

        public long DivisionId { get; set; }

        public string Cinema { get; set; }

        public string Hall { get; set; }

        public int[][] Seats { get; set; }

        public SessionStatus Status { get; set; }
    }
}
