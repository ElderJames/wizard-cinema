using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wizard.Cinema.Admin.Models
{
    public class DivisionModel
    {
        public long? DivisionId { get; set; }

        public long CityId { get; set; }

        public string Name { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
