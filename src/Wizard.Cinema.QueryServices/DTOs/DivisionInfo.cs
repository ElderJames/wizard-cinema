using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.QueryServices.DTOs
{
    public class DivisionInfo
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
