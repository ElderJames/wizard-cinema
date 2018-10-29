using System;
using System.Collections.Generic;
using System.Text;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.QueryServices
{
    public interface ISelectSeatTaskQueryService
    {
        IEnumerable<SelectSeatTaskInfo> Query(long sessionId);

        SelectSeatTaskInfo QueryByWizardId(long wizardId);
    }
}
