using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Ministry
{
    /// <summary>
    /// 分部信息
    /// </summary>
    public class Divisions
    {
        public long DivisionId { get; private set; }

        public long CityId { get; private set; }

        public int TotalMember { get; private set; }
    }
}
