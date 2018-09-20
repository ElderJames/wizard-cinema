using Infrastructures;

namespace Wizard.Cinema.Application.DTOs.Request.Cinema
{
    public class SearchSessionReqs : PagedSearch
    {
        public long? DivisionId { get; set; }
    }
}
