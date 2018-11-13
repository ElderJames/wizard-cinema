using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wizard.Cinema.Admin.Quartz
{
    public class JobAttribute : Attribute
    {
        public string Cron { get; set; }

        public string JobName { get; set; }
    }
}
