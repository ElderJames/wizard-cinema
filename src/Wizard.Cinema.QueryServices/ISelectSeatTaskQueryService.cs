using System;
using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.EnumTypes;
using Wizard.Cinema.QueryServices.DTOs.Cinema;
using Wizard.Cinema.QueryServices.DTOs.Sessions;

namespace Wizard.Cinema.QueryServices
{
    public interface ISelectSeatTaskQueryService
    {
        PagedData<SelectSeatTaskInfo> QueryPaged(SearchSelectSeatTaskCondition condition);

        IEnumerable<SelectSeatTaskInfo> QueryByWizardId(long sessionId, long wizardId);

        IEnumerable<SelectSeatTaskInfo> QueryByOverdueBeginTime(IEnumerable<long> sessionIds, SelectTaskStatus status, DateTime overdueBeginTime);
    }
}
