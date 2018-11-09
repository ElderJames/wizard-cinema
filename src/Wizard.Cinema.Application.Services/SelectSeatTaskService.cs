using System;
using System.Collections.Generic;
using Infrastructures;
using Infrastructures.Attributes;
using Wizard.Cinema.Application.DTOs.Request.Session;
using Wizard.Cinema.Application.DTOs.Response;
using Wizard.Cinema.Domain.Cinema;
using Wizard.Cinema.QueryServices;
using Wizard.Cinema.QueryServices.DTOs.Cinema;
using Wizard.Cinema.QueryServices.DTOs.Sessions;

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

        public ApiResult<PagedData<SelectSeatTaskResp>> Search(SearchSelectSeatTaskReqs request)
        {
            SearchSelectSeatTaskCondition condition = Mapper.Map<SearchSelectSeatTaskReqs, SearchSelectSeatTaskCondition>(request);
            PagedData<SelectSeatTaskInfo> tasks = _seatTaskQueryService.QueryPaged(condition);

            return new ApiResult<PagedData<SelectSeatTaskResp>>(ResultStatus.SUCCESS, Mapper.Map<PagedData<SelectSeatTaskInfo>, PagedData<SelectSeatTaskResp>>(tasks));
        }

        public ApiResult<IEnumerable<SelectSeatTaskResp>> GetByWizardId(long sessionId, long wizardId)
        {
            IEnumerable<SelectSeatTaskInfo> tasks = _seatTaskQueryService.QueryByWizardId(sessionId, wizardId);
            return new ApiResult<IEnumerable<SelectSeatTaskResp>>(ResultStatus.SUCCESS, Mapper.Map<SelectSeatTaskInfo, SelectSeatTaskResp>(tasks));
        }
    }
}
