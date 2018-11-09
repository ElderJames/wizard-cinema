using System;
using System.Collections.Generic;
using Infrastructures;
using Infrastructures.Attributes;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Cinema;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs.Cinema;

namespace Wizard.Cinema.Application.Services
{
    [Service]
    public class SelectSeatTaskService : ISelectSeatTaskService
    {
        private readonly ISelectSeatTaskQueryService _seatTaskQueryService;
        private readonly ISelectSeatTaskRepository _selectSeatTaskRepository;

        public SelectSeatTaskService(ISelectSeatTaskQueryService seatTaskQueryService,
            ISelectSeatTaskRepository selectSeatTaskRepository)
        {
            this._seatTaskQueryService = seatTaskQueryService;
            this._selectSeatTaskRepository = selectSeatTaskRepository;
        }

        /// <summary>
        /// 登记预约
        /// </summary>
        /// <param name="wizardId"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public ApiResult<bool> CheckIn(long wizardId, long sessionId)
        {
            //IEnumerable<SelectSeatTask> tasks = selectSeatTaskRepository.QueryByWizardId(sessionId, wizardId);
            //if (tasks == null || tasks.IsNullOrEmpty())
            //    return new ApiResult<bool>(ResultStatus.FAIL, "你不在排队中，请联系管理员");

            //tasks.ForEach(x =>
            //{
            //    x.CheckIn()
            //});
            throw new NotImplementedException();
        }

        public ApiResult<IEnumerable<SelectSeatTaskResp>> Search(long sessionId)
        {
            if (sessionId <= 0)
                return new ApiResult<IEnumerable<SelectSeatTaskResp>>(ResultStatus.FAIL, "请选择正确的场次");

            IEnumerable<SelectSeatTaskInfo> tasks = _seatTaskQueryService.Query(sessionId);

            return new ApiResult<IEnumerable<SelectSeatTaskResp>>(ResultStatus.SUCCESS, Mapper.Map<SelectSeatTaskInfo, SelectSeatTaskResp>(tasks));
        }

        public ApiResult<IEnumerable<SelectSeatTaskResp>> GetByWizardId(long sessionId, long wizardId)
        {
            IEnumerable<SelectSeatTaskInfo> tasks = _seatTaskQueryService.QueryByWizardId(sessionId, wizardId);
            return new ApiResult<IEnumerable<SelectSeatTaskResp>>(ResultStatus.SUCCESS, Mapper.Map<SelectSeatTaskInfo, SelectSeatTaskResp>(tasks));
        }
    }
}
