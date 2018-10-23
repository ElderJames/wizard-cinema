using System.Collections.Generic;
using Infrastructures;
using Wizard.Cinema.Application.DTOs.Response;

namespace Wizard.Cinema.Application.Services
{
    public interface ISeatService
    {
        /// <summary>
        /// 选择座位
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="seatNo"></param>
        /// <returns></returns>
        ApiResult<bool> Select(long wizardId, long sessionId, string[] seatNos);

        /// <summary>
        /// 获取被用户选择了的座位
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="wizardId"></param>
        /// <returns>已选择的座位</returns>
        ApiResult<string[]> GetSeats(long sessionId, long wizardId);

        /// <summary>
        /// 获取某场次的座位信息
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        ApiResult<IEnumerable<SeatResp>> GetBySession(long sessionId);

        /// <summary>
        /// 获取某活动的座位信息
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        ApiResult<IEnumerable<SeatResp>> GetByActivity(long activityId);
    }
}
