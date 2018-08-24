using System;

namespace Wizard.Infrastructures
{
    public class PagedSearch
    {
        public int PageSize { get; set; } = 15;

        public int PageNow { get; set; } = 1;

        public int StartIndex => (PageNow - 1) * PageSize;

        public int EndIndex => PageNow * PageSize - 1;

        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
