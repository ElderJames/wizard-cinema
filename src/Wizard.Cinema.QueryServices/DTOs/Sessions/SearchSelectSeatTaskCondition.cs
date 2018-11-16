using Infrastructures;
using Wizard.Cinema.Application.DTOs.EnumTypes;

namespace Wizard.Cinema.QueryServices.DTOs.Sessions
{
    public class SearchSelectSeatTaskCondition : PagedSearch
    {
        public long? SessionId { get; set; }

        public SelectTaskStatus? Status { get; set; }
    }
}
