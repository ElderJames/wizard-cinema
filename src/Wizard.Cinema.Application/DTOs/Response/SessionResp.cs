using System.Collections.Generic;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.Application.DTOs.Response
{
    public class SessionResp
    {
        public long SessionId { get; private set; }

        public long DivisionId { get; private set; }

        public string Cinema { get; private set; }

        public string Hall { get; private set; }

        public IEnumerable<long[]> Seats { get; private set; }

        public SessionStatus Status { get; private set; }
    }
}
