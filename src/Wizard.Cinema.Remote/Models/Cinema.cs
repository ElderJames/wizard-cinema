using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Remote.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public string Address { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}