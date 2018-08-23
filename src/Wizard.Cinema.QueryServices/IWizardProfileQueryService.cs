using Wizard.Cinema.Infrastructures;
using Wizard.Cinema.QueryServices.DTOs;

namespace Wizard.Cinema.QueryServices
{
    public interface IWizardProfileQueryService
    {
        ProfileInfo Query(long wizardId);

        ProfileInfo Query(string account, string passwardMd5);
    }
}
