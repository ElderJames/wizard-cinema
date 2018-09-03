using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Application.Services.Dto.Request
{
    public class CreateDivisionReqs
    {
        public long CityId { get; set; }

        public string Name { get; set; }

        public long CreatorId { get; set; }
    }
}
