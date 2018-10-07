using Infrastructures;

namespace Wizard.Cinema.QueryServices.DTOs.Activity
{
    public class SearchActivityCondition : PagedSearch
    {
        public long? DivisionId { get; set; }
    }
}
