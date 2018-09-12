using Infrastructures;

namespace Wizard.Cinema.Application.Services.Dto.Request.Wizards
{
    public class SearchWizardReqs : PagedSearch
    {
        public bool IsAdmin { get; set; }
    }
}
