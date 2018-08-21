using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wizard.Cinema.Admin.Models
{
    public class User
    {
        public long? UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
