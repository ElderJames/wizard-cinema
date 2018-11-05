using System.Collections.Generic;
using Wizard.Cinema.Domain.Cinema.EnumTypes;

namespace Wizard.Cinema.Domain.Cinema
{
    public interface ISelectSeatTaskRepository
    {
        void BatchInsert(SelectSeatTask[] tasks);

        void Start(SelectSeatTask task);

        void Select(SelectSeatTask task);

        SelectSeatTask Query(long taskId);

        IEnumerable<SelectSeatTask> QueryByWizardId(long sessionId, long wizardId, SelectTaskStatus? status = null);

        SelectSeatTask QueryNextTask(long sessionId, int serialNo);
    }
}
