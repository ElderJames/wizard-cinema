using System;
using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;

namespace Wizard.Cinema.Application.Services
{
    public interface ISelectSeatTaskService
    {
        /// <summary>
        /// 签到排队
        /// </summary>
        /// <returns></returns>
        ApiResult<bool> CheckIn(long wizardId, long sessionId);

        /// <summary>
        /// 设置成超时
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        ApiResult<bool> SetOverdue(long sessionId, long taskId);

        /// <summary>
        /// 查看队列
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        ApiResult<PagedData<SelectSeatTaskResp>> Search(SearchSelectSeatTaskReqs request);

        /// <summary>
        /// 查询个人状态
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="wizardId"></param>
        /// <returns></returns>
        ApiResult<IEnumerable<SelectSeatTaskResp>> GetByWizardId(long sessionId, long wizardId);

        /// <summary>
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="overdueTime"></param>
        /// <returns></returns>
        ApiResult<IEnumerable<SelectSeatTaskResp>> GetOverdueTask(IEnumerable<long> sessionIds, DateTime overdueTime);
    }
}
