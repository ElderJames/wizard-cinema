using Infrastructures;

namespace Wizard.Cinema.Remote.Repository.Condition
{
    public class SearchCinemaCondition : PagedSearch
    {
        public int CityId { get; set; }

        public string Keyword { get; set; }
    }
}
