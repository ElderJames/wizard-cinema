using Infrastructures;

namespace Wizard.Cinema.QueryServices.DTOs.Cinema
{
    public class SearchSessionCondition : PagedSearch
    {
        public long? DivisionId { get; set; }
    }
}
