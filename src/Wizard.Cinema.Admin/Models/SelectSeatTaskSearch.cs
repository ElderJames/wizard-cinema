using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;

namespace Wizard.Cinema.Admin.Models
{
    public class SelectSeatTaskSearch : PagedSearch
    {
        public long SessionId { get; set; }
    }
}
