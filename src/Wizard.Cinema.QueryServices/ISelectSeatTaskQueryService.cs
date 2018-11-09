using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.QueryServices.DTOs.Cinema;
using Wizard.Cinema.QueryServices.DTOs.Sessions;

namespace Wizard.Cinema.QueryServices
{
    public interface ISelectSeatTaskQueryService
    {
        PagedData<SelectSeatTaskInfo> QueryPaged(SearchSelectSeatTaskCondition condition);

        IEnumerable<SelectSeatTaskInfo> QueryByWizardId(long sessionId, long wizardId);
    }
}
