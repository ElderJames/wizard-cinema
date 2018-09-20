using System;
using System.Collections.Generic;
using System.Text;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Request.Cinema
{
    public class CreateSessionReqs
    {
        public long SessionId { get; set; }

        public long DivisionId { get; set; }

        public string Cinema { get; set; }

        public string Hall { get; set; }

        public IEnumerable<long[]> Seats { get; set; }

        public SessionStatus Status { get; set; }
    }
}
