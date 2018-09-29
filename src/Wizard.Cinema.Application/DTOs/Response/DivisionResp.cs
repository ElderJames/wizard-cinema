using System;

namespace Wizard.Cinema.Application.DTOs.Response
{
    public class DivisionResp
    {
        public int Id { get; set; }

        public long DivisionId { get; set; }

        public long CityId { get; set; }

        public string Name { get; set; }

        public int TotalMember { get; set; }

        public long CreatorId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
