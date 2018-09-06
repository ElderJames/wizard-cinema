using System;

namespace Wizard.Cinema.Application.DTOs.Request
{
    public class ChangeDivisionReqs
    {
        public long DivisionId { get; set; }

        public long CityId { get; set; }

        public string Name { get; set; }

        public long CreatorId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
