using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wizard.Cinema.Admin.Models
{
    public class CreateDivisionModel
    {
        public long CityId { get; set; }

        public string Name { get; set; }

        public long CreatorId { get; set; }
    }
}
