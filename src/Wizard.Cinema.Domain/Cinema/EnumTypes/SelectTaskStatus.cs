using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Cinema.EnumTypes
{
    public enum SelectTaskStatus
    {
        待开始 = 0,
        排队中 = 5,
        进行中 = 10,
        已完成 = 15,
        超时并结束 = 20
    }
}
