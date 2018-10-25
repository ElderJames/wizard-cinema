using System;
using System.Collections.Generic;
using System.Text;
using Infrastructures;

namespace Wizard.Cinema.Application.Services
{
    public interface ISelectSeatTaskService
    {
        ApiResult<bool> Create();
    }
}
