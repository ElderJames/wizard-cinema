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

        public string Name { get; private set; }

        public int TotalMember { get; private set; }

        public long CreatorId { get; private set; }

        public DateTime CreateTime { get; set; }

        public Divisions(long divisionId, long cityId, string name, long creatorId)
        {
            this.DivisionId = divisionId;
            this.CityId = cityId;
            this.Name = name;
            this.CreatorId = creatorId;
            this.CreateTime = DateTime.Now;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void AddMember()
        {
            this.TotalMember++;
        }
    }
}
