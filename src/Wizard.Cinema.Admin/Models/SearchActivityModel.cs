using Infrastructures;

namespace Wizard.Cinema.Admin.Models
{
    public class SearchActivityModel : PagedSearch
    {
        public long? DivisionId { get; set; }
    }
}
