using System.Collections.Generic;
using System.Linq;

namespace Wizard.Cinema.Infrastructures
{
    public class PagedData<TRecord>
    {
        public PagedData()
        {
        }

        public PagedData(int pageSize, int pageNow)
        {
            PageSize = pageSize;
            PageNow = pageNow;
            TotalCount = 0;
            Records = Enumerable.Empty<TRecord>();
        }

        public int PageSize { get; set; }

        public int PageNow { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<TRecord> Records { get; set; }
    }
}
