using System.Collections.Generic;
using System.Linq;

namespace Infrastructures
{
    public class PagedData<TRecord>
    {
        public PagedData()
        {
        }

        public PagedData(int pageSize, int pageNow, int totalCount, IEnumerable<TRecord> records)
        {
            PageSize = pageSize;
            PageNow = pageNow;
            TotalCount = totalCount;
            Records = records;
        }

        public PagedData(int pageSize, int pageNow) : this(pageSize, pageNow, 0, Enumerable.Empty<TRecord>())
        {
        }

        public int PageSize { get; set; }

        public int PageNow { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<TRecord> Records { get; set; } = Enumerable.Empty<TRecord>();

        public override string ToString()
        {
            return $"PageSize={PageSize},PageNow={PageNow},TotalCount={TotalCount},Records.Count={Records?.Count()}";
        }
    }
}
