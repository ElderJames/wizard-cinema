﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Wizard.Cinema.Domain.Cinema.EnumTypes
{
    public enum SelectTaskStatus
    {
        待开始 = 0,
        进行中 = 5,
        已完成 = 10,
        超时并结束 = 15
    }
}