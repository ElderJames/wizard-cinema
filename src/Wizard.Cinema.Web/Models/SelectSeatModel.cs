using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wizard.Cinema.Web.Models
{
    public class SelectSeatModel
    {
        public long SessionId { get; set; }

        public string[] SeatNos { get; set; }
    }
}
