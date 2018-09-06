using System;

namespace Wizard.Cinema.Application.DTOs.Request.Division
{
    public class CreateDivisionReqs
    {
        public long CityId { get; set; }

        public string Name { get; set; }

        public long CreatorId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
