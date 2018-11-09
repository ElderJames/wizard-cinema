using System.Collections.Generic;
using Wizard.Cinema.Domain.Cinema.EnumTypes;

namespace Wizard.Cinema.Domain.Cinema
{
    public interface ISelectSeatTaskRepository
    {
        void BatchInsert(SelectSeatTask[] tasks);

        int Start(SelectSeatTask task);

        int Select(SelectSeatTask task);

        SelectSeatTask Query(long taskId);

        SelectSeatTask QueryCurrent(long sessionId);

        IEnumerable<SelectSeatTask> QueryBySessionId(long sessionId);

        IEnumerable<SelectSeatTask> QueryByWizardId(long sessionId, long wizardId, SelectTaskStatus? status = null);

        SelectSeatTask QueryNextTask(long sessionId, int serialNo);

        void CheckIn(IEnumerable<SelectSeatTask> tasks);
    }
}
