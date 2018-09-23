using System.Collections.Generic;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.QueryServices.DTOs.Cinema
{
    public class SessionInfo
    {
        public long SessionId { get; set; }

        public long DivisionId { get; set; }

        public long CinemaId { get; set; }

        public long HallId { get; set; }

        public int[][] Seats { get; set; }

        public SessionStatus Status { get; set; }
    }
}
