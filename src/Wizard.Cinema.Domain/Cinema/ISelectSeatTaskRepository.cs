using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Cinema
{
    public interface ISelectSeatTaskRepository
    {
        void BatchInsert(SelectSeatTask[] tasks);
    }
}
