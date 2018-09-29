using Infrastructures;

namespace Wizard.Cinema.Application.DTOs.Request.Session
{
    public class SearchSessionReqs : PagedSearch
    {
        public long? DivisionId { get; set; }
    }
}
