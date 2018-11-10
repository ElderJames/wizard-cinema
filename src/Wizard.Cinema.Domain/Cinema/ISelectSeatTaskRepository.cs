using System.Collections.Generic;
using Wizard.Cinema.Domain.Cinema.EnumTypes;

namespace Wizard.Cinema.Domain.Cinema
{
    public interface ISelectSeatTaskRepository
    {
        int BatchInsert(IEnumerable<SelectSeatTask> tasks);

        int Start(SelectSeatTask task);

        int Select(SelectSeatTask task);

        SelectSeatTask Query(long taskId);

        SelectSeatTask QueryCurrent(long sessionId);

        SelectSeatTask QuerySessionNextTask(long sessionId);

        IEnumerable<SelectSeatTask> QueryBySessionId(long sessionId);

        IEnumerable<SelectSeatTask> QueryByWizardId(long sessionId, long wizardId, SelectTaskStatus? status = null);

        SelectSeatTask QueryNextTask(SelectSeatTask task);

        int CheckIn(IEnumerable<SelectSeatTask> tasks);

        int CheckInAgain(IEnumerable<SelectSeatTask> tasks);

        int SetTimeout(SelectSeatTask task);
    }
}
